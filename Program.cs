namespace RomanToInteger {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine(RomanToInt("MCMXCIV"));
        }

        public static int RomanToInt(string s) {
            int totalRomanNumber = 0;

            Dictionary<char, int> myRomanDictionary = new Dictionary<char, int>();
            /*
                I             1
                V             5
                X             10
                L             50
                C             100
                D             500
                M             1000
             */
            char[] romanCharacters = {'I', 'V', 'X', 'L', 'C', 'D', 'M'};
            int[] numbers = { 1, 5, 10, 50, 100, 500, 1000 };
            for(int i = 0; i < numbers.Length; i++) {
                myRomanDictionary.Add(romanCharacters[i], numbers[i]);
            }
            char[] inputedRomanNumeral = s.ToCharArray();

            List<int> tempNum = new List<int>();

            for(int i = 0; i < inputedRomanNumeral.Length; i++) {
                for(int j = 0; j < numbers.Length; j++) {
                    if(inputedRomanNumeral[i].Equals(myRomanDictionary.ElementAt(j).Key) && i == 0){
                        tempNum.Add(myRomanDictionary.ElementAt(j).Value);
                        continue;
                    }

                    if(inputedRomanNumeral[i].Equals(myRomanDictionary.ElementAt(j).Key)) {
                        if(myRomanDictionary.ElementAt(j).Value > tempNum[tempNum.Count - 1]) {
                            int tempNumberholder = tempNum[tempNum.Count - 1];
                            tempNum.RemoveAt(tempNum.Count - 1);
                            tempNum.Add(myRomanDictionary.ElementAt(j).Value - tempNumberholder);
                            continue;
                        }

                        tempNum.Add(myRomanDictionary.ElementAt(j).Value);
                    }
                }
            }

            foreach(var n in tempNum) {
                totalRomanNumber += n;
            }


            return totalRomanNumber;
        }
    }
}
