import unittest
from Calculator import Calculator

class CalculatorTest(unittest.TestCase):
    def test_ReadjustSalary(self):
        self.assertEqual(Calculator.readjustSalary(1000), 1200)
        self.assertEqual(Calculator.readjustSalary(2000), 2300)
        self.assertEqual(Calculator.readjustSalary(4000), 4400)
        self.assertEqual(Calculator.readjustSalary(7000), 7350)

    def test_valueErrorReadjustSalary(self):
        with self.assertRaises(ValueError):
            Calculator.readjustSalary(-200)
    
    def test_typeErrorReadjustSalary(self):
        with self.assertRaises(TypeError): 
            Calculator.readjustSalary("200")

if __name__ == '__main__':
    unittest.main()