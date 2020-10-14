using System;
using System.Configuration;

namespace RIOMS.WebUI.Util
{
    public class Util
    {
        public static string ConvertAmountToWords(decimal amount)
        {
            string word = ConvertAmountToWords(Convert.ToInt32(amount * 100) / 100) + " rupees " + (ConvertAmountToWords(Convert.ToInt32(amount * 100) % 100) != "0" ? ConvertAmountToWords(Convert.ToInt32(amount * 100) % 100) + " paise " : " ") + "  only";
            return word.ToLower();
        }

        private static string ConvertAmountToWords(int amount)
        {
            if (amount == 0)
                return "0";
            if (amount < 0)
                return ConvertAmountToWords(Math.Abs(amount));
            string words = "";
            if ((amount / 1000000) > 0)
            {
                words += ConvertAmountToWords(amount / 1000000) + " MILLION ";
                amount %= 1000000;
            }
            if ((amount / 1000) > 0)
            {
                words += ConvertAmountToWords(amount / 1000) + " THOUSAND ";
                amount %= 1000;
            }
            if ((amount / 100) > 0)
            {
                words += ConvertAmountToWords(amount / 100) + " HUNDRED ";
                amount %= 100;
            }
            if (amount > 0)
            {
                //if (words != "")
                //    words += "AND ";
                var unitsMap = new[] { "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN" };
                var tensMap = new[] { "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" };

                if (amount < 20)
                    words += unitsMap[Convert.ToInt32(amount)];
                else
                {
                    words += tensMap[Convert.ToInt32(amount) / 10];
                    if ((amount % 10) > 0)
                        words += " " + unitsMap[Convert.ToInt32(amount) % 10];
                }
            }
            return words;
        }

        public static string ConvertAmountToWordOdia(decimal amount)
        {
            string word = ConvertAmountToWordOdia(Convert.ToInt32(amount * 100) / 100) + " ଟଙ୍କା " + (ConvertAmountToWordOdia(Convert.ToInt32(amount * 100) % 100) != "0" ? ConvertAmountToWordOdia(Convert.ToInt32(amount * 100) % 100) + " ପଇସା" : "") + " ମାତ୍ର";
            return word;
        }

        private static string ConvertAmountToWordOdia(int amount)
        {
            if (amount == 0)
                return "0";
            if (amount < 0)
                return ConvertAmountToWordOdia(Math.Abs(amount));
            string words = "";
            if ((amount / 100000) > 0)
            {
                words += ConvertAmountToWordOdia(amount / 100000) + " ଲକ୍ଷ ";
                amount %= 100000;
            }
            if ((amount / 1000) > 0)
            {
                words += ConvertAmountToWordOdia(amount / 1000) + " ହଜାର ";
                amount %= 1000;
            }
            if ((amount / 100) > 0)
            {
                words += ConvertAmountToWordOdia(amount / 100) + " ଶହ ";
                amount %= 100;
            }
            if (amount > 0)
            {
                if (words != "")
                    words += " ";
                var unitsMap = new[] {
                   "ଶୁନ୍ୟ",
                   "ଏକ",
"ଦୁଇ",
"‍ତିନି",
"ଚାରି",
"ପାଞ୍ଚ",
"ଛଅ",
"ସାତ",
"ଆଠ",
"ନଅ",
"ଦଶ",
"ଏଗାର",
"ବାର",
"ତେର",
"ଚଉଦ",
"ପନ୍ଦର",
"ଷୋଳ",
"ସତର",
"ଅଠର",
"ଉଣେଇଶ",
"କୋଡିଏ",
"ଏକୋଇଶ",
"ବାଇଶ",
"ତେଇଶ",
"ଚବିଶ",
"ପଚିଶ",
"ଛବିଶ",
"ସତେଇଶ",
"ଅଠେଇଶ",
"ଅଣତିରିଶ",
"ତିରିଶ",
"ଏକତିରିଶ",
"ବତିଶ",
"ତେତିଶ",
"ଚଉତିରିଶ",
"ପଞ୍ଚତିରିଶି",
"‍ଛତିଶି",
"ସଂଇତିରିଶ",
"ଅଠତିରିଶ",
"ଅଣଚାଳିଶ",
"ଚାଳିଶ",
"ଏକଚାଳିଶ",
"ବୟାଳିଶ",
"ତେୟାଳିଶ",
"ଚଉରାଳିଶ",
"ପଞ୍ଚଚାଳିଶ",
"ଛୟାଳିଶ",
"ସତଚାଳିଶ",
"ଅଠଚାଳିଶ",
"ଅଣଚାଶ",
"ପଚାଶ",
"ଏକାବନ",
"ବାଉନ",
"ତେପନ",
"ଚଉବନ",
"ପଞ୍ଚାବନ",
"ଛପନ",
"ସତାବନ",
"ଅଠାବନ",
"ଅଣଷଠି",
"ଷାଠିଏ",
"ଏକଷଠି",
"ବାଷଠି",
"ତେଷଠି",
"ଚଉଷଠି",
"ପଞ୍ଚଷଠି",
"ଛଅଷଠି",
"ସତଷଠି",
"ଅଠଷଠି",
"ଅଣସ୍ତରୀ",
"ସତୂରୀ",
"ଏକସ୍ତରୀ",
"ବାସ୍ତରୀ",
"ତେସ୍ତରୀ",
"ଚଉସ୍ତରୀ",
"ପଞ୍ଚସ୍ତରୀ",
"ଛଅସ୍ତରୀ",
"ସତସ୍ତରୀ",
"ଅଠସ୍ତରୀ",
"ଅଣାଅଶୀ",
"ଅଶୀ",
"ଏକାଅଶୀ",
"ବୟାଅଶୀ",
"ତେୟାଅଶୀ",
"ଚଉରାଅଶୀ",
"ପଞ୍ଚାଅଶୀ",
"ଛୟାଅଶୀ",
"ସତାଅଶୀ",
"ଅଠାଅଶୀ",
"ଅଣାନବେ",
"ନବେ",
"ଏକାନବେ",
"ବୟାନବେ",
"ତେୟାନବେ",
"ଚଉରାନବେ",
"ପଞ୍ଚାନବେ",
"ଛୟାନବେ",
"ସତାନବେ",
"ଅଠାନବେ",
"ଅନେଶତ",
"ଶହେ"
 };

                if (amount < 100)
                    words += unitsMap[Convert.ToInt32(amount)];
            }
            return words;
        }

        public static int RICId
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["RICId"]);
            }
        }
    }
}