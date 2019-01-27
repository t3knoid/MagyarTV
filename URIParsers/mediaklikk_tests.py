import unittest
from mediaklikk import MediaKlikk

class Test_mediaklikk_tests(unittest.TestCase):
    def M1(self):
        """ Checks that we can get M1 URI """
        mediaklikk = MediaKlikk()
        uri = mediaklikk.GetURI(mediaklikk.M1.indexfeed)
        self.assertFalse(not uri)

if __name__ == '__main__':
    unittest.main()
