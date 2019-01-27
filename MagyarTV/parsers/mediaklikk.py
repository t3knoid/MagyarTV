import requests
import urlparse
from bs4 import BeautifulSoup
import getopt
import sys

def geturi(index):
    """ Returns the URI for a given index
        THis parses URI from https://www.mediaklikk.hu/
    """

    search_str = "\/index.m3u8"
    high_res_m3u = "02.m3u8"

    # Read index feed
    page = requests.get(index)
    tree = BeautifulSoup(page.content, 'html.parser')
    scripts = tree.find_all('script')
    script = scripts[6].text

    # Split the script into a list of individual lines
    lines = script.split('\n')

    # Get the line containing index.m3u8
    found_line = [s for s in lines if (search_str in s)][0]

    url_parts = found_line.split('"')
    m3u8_index = 'https:%s' % url_parts[3].replace('\\', '')

    high_res_video = urlparse.urljoin(m3u8_index, high_res_m3u)
    # print('%s' % high_res_video)
    return high_res_video

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
print uri
