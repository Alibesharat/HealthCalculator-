using System;
using System.Collections.Generic;
using System.Text;

namespace HealthCalculator
{
  public  class BMI
    {
        private double _height { get; set; }
        private double _weight { get; set; }

        public BMI(double height,double weight)
        {
            _height = height;
            _weight = weight;
        }



        public (double,string) Calc()
        {
            if(_height<=0 || _weight <= 0)
            {
                return (-1,"پارامتر قد و وزن صحیح وارد نشده است");
            }
            else
            {
                var result = _weight / (_height * _height);
                string message = "";
                if (result > 16.5)
                    message = "کمبود وزن شدید";
                else if (result >= 16.15 && result < 18.5)
                    message = "کمبود وزن";
                else if (result >= 18.5 && result < 25)
                    message = "عادی";
                else if (result >= 25 && result < 30)
                    message = "اضافه وزن ";
                else if (result >= 30 && result < 35)
                    message = "چاقی کلاس ۱ ";
                else if (result >= 35 && result < 40)
                    message = "چاقی کلاس 2 ";
                else if (result >= 40)
                    message = "چاقی کلاس 3";
                return (result, message);


            }
        }


    }
}
