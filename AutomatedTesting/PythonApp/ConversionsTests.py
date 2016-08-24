import unittest
import Conversions

class ConversionsTests(unittest.TestCase):

    def test_roomTemperature(self):
        self.assertEqual(Conversions.ToCelcius(68), 20)

    def test_boilingPoint(self):
        self.assertEqual(Conversions.ToCelcius(212), 100)

    def test_freezingPoint(self):
        self.assertEqual(Conversions.ToCelcius(32), 0)

    def test_bodyTemperature(self):
        self.assertEqual(Conversions.ToCelcius(98.4), 36.9)