#
# This parses a given video feed from Mediaklikk and
# prints the corresponding URI video stream. This 
# currently suppprots channels M1, M2, M4, M5, 
# Duna, and Duna World. A configured Python3
# environment is required to run this script.
# See the environment.txt file for required
# modules
#
import requests
from six.moves.urllib.parse import urlparse
from six.moves.urllib.parse import urljoin
from lxml import html
import sys, getopt

index_feed = None

try:
    opts, args = getopt.getopt(sys.argv[1:],"hi:",["ifile="])
except getopt.GetoptError:
    print ('getURI.py -i <inputfile>')
    sys.exit(2)
for opt, arg in opts:
    if opt == '-h':
        print ('test.py -i <inputfile>')
        sys.exit()
    elif opt in ("-i", "--ifile"):
        index_feed = arg 
        
search_str = "\/index.m3u8"
high_res_m3u = "02.m3u8"

# Read index feed
pageContent=requests.get(
     index_feed
)
tree = html.fromstring(pageContent.content)

# Get the script text containing the m3u8 index URL
script=tree.xpath(
    '/html/body/script[3]/text()')[0]

# Split the script into a list of individual lines
lines = script.split('\n')

# Get the line containing index.m3u8
found_line = [s for s in lines if (search_str in s)][0]

url_parts=found_line.split('"')
m3u8_index = 'https:%s' % url_parts[3].replace('\\', '')

# Get the m3u8 file so that we an parse the actual m3u8 page
#print '%s' % m3u8_index
#url_root = m3u8_index.rsplit('/', 1)[0]
#print '%s' % url_root

high_res_video = urljoin(m3u8_index, high_res_m3u)
print('%s' % high_res_video)

# write to a file
#f = open ("m3u_url.txt","w")
#f.write(high_res_video)
#f.close
