using System;
using System.Collections.Generic;
using System.Text;

namespace HealthCalculator
{
    public class IBW
    {
        private double _Height { get; set; }
        private bool _gender { get; set; }


        public IBW(double Height,bool gender)
        {
            _Height = Height;
            _gender = gender;
        }

        public double Calc()
        {
            if (_Height <= 0)
            {
                return -1;
            }
            var Inch_height = _Height / 2.54;
            double res;
            switch (_gender)
            {
                case true:
                     res = (50 + 2.3)*(Inch_height - 6);
                    break;
                case false:
                     res = (45.5 + 2.3) * (Inch_height - 6);
                    break;
                default:
                    throw new Exception("gender is not valid in range");
            }

            return res;
        }



    }
}
