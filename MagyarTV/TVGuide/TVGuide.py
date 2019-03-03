import sys
sys.path.append('lib')

import requests
from urllib.parse import urljoin
from urllib.parse import urlparse
from bs4 import BeautifulSoup
import getopt

index="http://tv.animare.hu/default.aspx?c=2&t=20190112"
page = requests.get(index)
soup = BeautifulSoup(page.text, 'html.parser')
print(soup.prettify())
