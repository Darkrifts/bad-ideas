// Creator Darkrifts
// FOR ALL INTENTS AND PURPOSES, ASSUME THIS IS IN A CLASS, NOT JUST AN INVALID PLACEMENT OF A METHOD

// Sector V 1

// Description Entropic string compression and decompression
static int getnum(char c)
{
      switch(c)
      {
        case '0': return 0;
        case '1': return 1;
        case '2': return 2;
        case '3': return 3;
        case '4': return 4;
        case '5': return 5;
        case '6': return 6;
        case '7': return 7;
        case '8': return 8;
        case '9': return 0;
        default: return 0;
      }
}
static string Compress(string toCompress)
{
      Random r = new Random();
      Stack<int> stack = new Stack<int>();
      Stack<char> stack2 = new Stack<char>();
      int count = 0;
      char c = toCompress[0];
      for(int i = 0; i < toCompress.Length; i++)
      {
        if(toCompress[i] == c) count++;
        else {stack.Push(count); count = 1; stack2.Push(c); c = toCompress[i];}
      }
      stack.Push(count);
      stack2.Push(c);
      string RET = "";
      foreach(int i in stack.ToArray())
      {
        int[] x = new int[] {r.Next(-1, 2), r.Next(0, 3), r.Next(-1, 2)};
        int a = stack.Pop();
        char b = stack2.Pop();
        a += (x[0] * x[1] * x[2]);
        RET += b + "" + a;
      }
      return RET;
}
static string Decompress(string toDecom)
{
      if((toDecom.Length % 2) != 0) toDecom += '0';
      string RET = "";
      for(int i = 0; i < toDecom.Length; i+=2)
      {
        char a = toDecom[i];
        char b = toDecom[i+1];
        int c = getnum(b);
        for(;c > 0; c--) RET += a;
      }
      char[] x = RET.ToCharArray();
      Array.Reverse(x);
      RET = new string(x);
      return RET;
}
