using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder();
            EqualsStrings();
            IsNullOrEmptyMethod();
            ConcatenatingStrings();
        }

        private static void ConcatenatingStrings()
        {
            var name = "Rodolfo";
            var familyName = "Fadino";
            var otherName = "Junior";

            var fullName = "Full Name: " + name + " " + familyName + " " + otherName;
            var fullNameBetter = string.Format("Full Name: {0} {1} {2}", name, familyName, otherName);
            var fullNameEvenBetter = $"Full Name: {name} {familyName} {otherName}";
        }

        private static void IsNullOrEmptyMethod()
        {
            var name = "rodolfo";
            name = null;
            if (name != "")
            {
                var result = name.Split('o');
            }

            if (name != "" && name != null)
            {
                var result = name.Split('o');
            }

            if (!string.IsNullOrEmpty(name))
            {
                var result = name.Split('o');
            }
        }

        private static void EqualsStrings()
        {
            var startA = DateTime.Now;
            for (int i = 0; i < 100000; i++)
            {
                var nameA = "Rodolfo";
                var nameACompare = "rodolfo";
                var resultA = nameA.ToLower() == nameACompare;
            }
            var endA = DateTime.Now;
            var totalA = (endA - startA).TotalMilliseconds;

            var start = DateTime.Now;
            for (int i = 0; i < 100000; i++)
            {
                var name = "Rodolfo";
                var nameCompare = "rodolfo";
                var result = string.Equals(name, nameCompare, StringComparison.CurrentCultureIgnoreCase);
            }
            var end = DateTime.Now;
            var total = (end - start).TotalMilliseconds;
        }

        private static void StringBuilder()
        {
            //ao concatenar strings utilizar o string builder :)
            var start = DateTime.Now;
            var content = "comeco";
            for (int i = 0; i < 10000; i++)
            {
                content += "conteudo_" + i;
            }
            var end = DateTime.Now;
            var total = (end - start).TotalMilliseconds;
            //331.6ms

            //string nome = string.Empty;
            var startBuilder = DateTime.Now;
            var builder = new StringBuilder("comeco");
            for (int i = 0; i < 10000; i++)
            {
                builder.AppendFormat("conteudo_{0}", i);
            }
            var endBuilder = DateTime.Now;

            var totalStringBuilder = (endBuilder - startBuilder).TotalMilliseconds;
            //2.5ms
        }
    }
}
