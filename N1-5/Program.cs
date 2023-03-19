// See https://aka.ms/new-console-template for more information



//1.დაწერეთ ფუნქცია, რომელსაც გადაეცემა ტექსტი და აბრუნებს
//პალინდრომია თუ არა. (პალინდრომი არის ტექსტი რომელიც ერთნაირად
//იკითხება ორივე მხრიდან).
//bool sPalindrome(string text);


 bool IsPalindrome(string str)
{
    int length = str.Length;
    for (int i = 0; i < length / 2; i++)
    {
        if (str[i] != str[length - i - 1])
        {
            return false;
        }
    }
    return true;
}

//usage: 
Console.Write("Plase enter a string:");
string myString = Console.ReadLine();
if (IsPalindrome(myString))
{
    Console.WriteLine("The string is a palindrome.");
}
else
{
    Console.WriteLine("The string is not a palindrome.");
}


//2.გვაქვს 1,5,10,20 და 50 თეთრიანი მონეტები.დაწერეთ ფუნქცია, რომელსაც
//გადაეცემა თანხა (თეთრებში) და აბრუნებს მონეტების მინიმალურ
//რაოდენობას, რომლითაც შეგვიძლია ეს თანხა დავახურდაოთ.

//int MinSplit(int amount);


 int MinSplit(int amount)
{
    int[] coins = { 1, 5, 10, 20, 50 };
    int count = 0;
    for (int i = 0; i < coins.Length; i++)
    {
        count += amount / coins[i];
        amount %= coins[i];
    }
    return count;
}

//usage
Console.Write("Please enter the amount of money(in georgian tetri):");
int myAmount = int.Parse(Console.ReadLine());
int count = MinSplit(myAmount);
Console.WriteLine($"The minimum number of georgian tetri needed to make {myAmount} is {count}.");



//3.მოცემულია მასივი, რომელიც შედგება მთელი რიცხვებისგან. დაწერეთ
//ფუნქცია რომელსაც გადაეცემა ეს მასივი და აბრუნებს მინიმალურ მთელ
//რიცხვს, რომელიც 0-ზე მეტია და ამ მასივში არ შედის.

//int NotContains(int[] array);

int NotContains(int[] array)
{
    int max = int.MinValue;
    bool[] isPresent = new bool[array.Length + 1]; // initialize to false

    for (int i = 0; i < array.Length; i++)
    {
        if (array[i] > max)
        {
            max = array[i];
        }
        if (array[i] > 0 && array[i] <= array.Length)
        {
            isPresent[array[i]] = true;
        }
    }

    for (int i = 1; i <= array.Length; i++)
    {
        if (!isPresent[i])
        {
            return i;
        }
    }
    return max + 1;
}


//usage
int[] myArray = { 2, 4, 6, 8, 10, 12, 14 };
int notPresent = NotContains(myArray);
Console.WriteLine($"The smallest positive integer that is not in the myArray is {notPresent}");

//4.მოცემულია String რომელიც შედგება „(„ და „)“ ელემენტებისგან.დაწერეთ
//ფუნქცია რომელიც აბრუნებს ფრჩხილები არის თუ არა მათემატიკურად
//სწორად დასმული.

//bool IsProperly(string sequence);

//მაგ: (()()) სწორი მიმდევრობაა, ())() არასწორია


bool IsProperly(string sequence)
{
    char openBracket = '(';
    char closeBracket = ')';
    int bracketCount = 0;

    foreach (char character in sequence)
    {
        if (character == openBracket)
        {
            bracketCount++;
        }
        else if (character == closeBracket)
        {
            bracketCount--;
        }

        if (bracketCount < 0)
        {
            return false;
        }
    }

    return bracketCount == 0;
}

//usage
Console.WriteLine("Enter a sequence of brackets:");
string sequence = Console.ReadLine();
bool isProperly = IsProperly(sequence);
Console.WriteLine("The sequence is properly bracketed: " + isProperly);



//გვაქვს n სართულიანი კიბე, ერთ მოქმედებაში შეგვიძლია ავიდეთ 1 ან 2
//საფეხურით. დაწერეთ ფუნქცია რომელიც დაითვლის n სართულზე ასვლის
//ვარიანტების რაოდენობას.

//int CountVariants(int stairCount);


int CountVariants(int stairCount)
{
    if (stairCount < 0)
    {
        throw new Exception("Please enter a number greater than 0.");
    }
    if (stairCount <= 1)
    {
        return 1;
    }

    int prev1 = 1;
    int prev2 = 1;
    int result = 0;

    for (int i = 2; i <= stairCount; i++)
    {
        result = prev1 + prev2;
        prev2 = prev1;
        prev1 = result;
    }

    return result;
}

//usage
Console.Write("Enter the number of stairs: ");
int n = int.Parse(Console.ReadLine());
try
{
    int variants = CountVariants(n);
    Console.WriteLine("Number of climbing variants: " + variants);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

