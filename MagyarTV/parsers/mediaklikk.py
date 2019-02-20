import sys
sys.path.append('lib')

import requests
from urllib.parse import urljoin
from urllib.parse import urlparse
from bs4 import BeautifulSoup
import getopt


def geturi(index):
    """ Returns the M3U8 URI for a given index from https://www.mediaklikk.hu/.

        An example M3U8 file looks like the following:
        #EXTM3U
        #EXT-X-VERSION:3
        #EXT-X-STREAM-INF:PROGRAM-ID=1,BANDWIDTH=468677,CODECS="avc1.42c00d,mp4a.40.2",RESOLUTION=320x180
        05.m3u8
        #EXT-X-STREAM-INF:PROGRAM-ID=1,BANDWIDTH=826286,CODECS="avc1.42c01e,mp4a.40.2",RESOLUTION=480x270
        04.m3u8
        #EXT-X-STREAM-INF:PROGRAM-ID=1,BANDWIDTH=1183894,CODECS="avc1.4d401e,mp4a.40.2",RESOLUTION=640x360
        03.m3u8
        #EXT-X-STREAM-INF:PROGRAM-ID=1,BANDWIDTH=1490416,CODECS="avc1.4d4028,mp4a.40.2",RESOLUTION=854x480
        02.m3u8
    """

    search_str = "\/index.m3u8"
    m3u8_index = ""
    found = False
    retries = 0

    # Read index feed
    while (not found) or (retries < 10):   # Retry at least 10x
        retries += 1
        page = requests.get(index)
        tree = BeautifulSoup(page.text, 'html.parser')
        scripts = tree.find_all('script')
        script = scripts[6].text

        # Split the script into a list of individual lines
        lines = script.split('\n')

        # Get the line containing index.m3u8
        found = [s for s in lines if (search_str in s)]

        if found:
            found_line = found[0]
            url_parts = found_line.split('"')
            m3u8_index = 'https:%s' % url_parts[3].replace('\\', '')

    m3u8_url = urljoin(m3u8_index,urlparse(m3u8_index).path)

    return m3u8_url

feed = None

try:
    opts, args = getopt.getopt(sys.argv[1:], "hi:", ["ifile="])
except getopt.GetoptError:
    print ('mediaklikk.py -i <inputfile>')
    sys.exit(2)
for opt, arg in opts:
    if opt == '-h':
        print ('mediaklikk.py -i <inputfile>')
        sys.exit()
    elif opt in ("-i", "--ifile"):
        feed = arg

uri = geturi(feed)
print('%s' % uri)
