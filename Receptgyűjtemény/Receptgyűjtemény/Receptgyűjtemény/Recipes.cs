using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receptgyűjtemény
{
    class Recipes
    {
        private string _name;
        private string _type;
        private string[] _ingredient;
        private string _preparation;


        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public string[] Ingredient
        {
            get { return _ingredient; }
            set { _ingredient = value; }
        }
        public string Preparation
        {
            get { return _preparation; }
            set { _preparation = value; }
        }

        public Recipes(string name_, string type_, string[] ingredient_, string preparation_)
        {
            _name = name_;
            _type = type_;
            _ingredient = ingredient_;
            _preparation = preparation_;
        }


    }
}
