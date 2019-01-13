
import requests
from six.moves.urllib.parse import urlparse
from six.moves.urllib.parse import urljoin
from lxml import html


search_str = "\/index.m3u8"
index_feed = 'https://player.mediaklikk.hu/playernew/player.php?video=mtv2live'
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
f = open ("m3u_url.txt","w")
f.write(high_res_video)
f.close

#m3u8_index_pageContent=requests.get(
#     m3u8_index
#)
#if pageContent.status_code == 200:
#    print '%s' % m3u8_index_pageContent.content