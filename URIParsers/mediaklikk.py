from channel import Channel
import requests
import urlparse
from bs4 import BeautifulSoup

# These are channels from https://www.mediaklikk.hu/

class MediaKlikk(object):
    """Define MediaKlikk channels"""
    country = "Hungary"
    language = "Hungarian"

    # Defines M1 channel
    M1 = Channel()
    M1.name = "M1"
    M1.indexfeed = "https://player.mediaklikk.hu/playernew/player.php?video=mtv1live" 

    # Defines M2 channel
    M2 = Channel()
    M2.name = "M2"
    M2.indexfeed = "https://player.mediaklikk.hu/playernew/player.php?video=mtv2live" 

    M4 = Channel()
    # Defines M4 channel
    M4.name = "M4"
    M4.indexfeed = "https://player.mediaklikk.hu/playernew/player.php?video=mtv4live" 

    M5 = Channel()
    # Defines M2 channel
    M5.name = "M5"
    M5.indexfeed = "https://player.mediaklikk.hu/playernew/player.php?video=mtv5live" 

    Duna = Channel()
    # Defines Duna channel
    Duna.name = "Duna"
    Duna.indexfeed = "https://player.mediaklikk.hu/playernew/player.php?video=dunalive" 

    DunaWorld = Channel()
    # Defines DunaWorld channel 
    DunaWorld.name = "Duna World"
    DunaWorld.indexfeed = "https://player.mediaklikk.hu/playernew/player.php?video=dunaworld" 

    def GetURI(self,index):
        """ Returns the URI for a given index """
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

        url_parts=found_line.split('"')
        m3u8_index = 'https:%s' % url_parts[3].replace('\\', '')

        high_res_video = urlparse.urljoin(m3u8_index, high_res_m3u)
        # print('%s' % high_res_video)
        return high_res_video
