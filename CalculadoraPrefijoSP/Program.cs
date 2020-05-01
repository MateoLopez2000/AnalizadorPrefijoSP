using System;
using System.Collections;

namespace CalculadoraPrefijoSP
{
    class Program
    {
        public static char l;
        public static int i = 0;
        public static bool a = true;
        public static int valor = 0;
        public static int result;
        public static double result2;

        public static string temporary = "";
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("************Calculadora de Prefijo***********");
            Console.WriteLine("Elija una opcion\n1.-Calculadora Enteros\n2.-Calculadora Flotantes\n3.-Calculadora Enteros y Flotantes\n4.-Salir");
            string op = Console.ReadLine();
            do
            {
                switch (op)
                {
                    case "1":
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Ingrese la Expresion Entera");
                            String cadenaAux = Console.ReadLine().ToString();
                            String cadena = string.Concat(cadenaAux, "$");
                            Stack IntStack = new Stack();
                            char[] characters = cadena.ToCharArray();
                            i = 0;
                            l = getChara(characters);
                            LEXP(characters);
                            if (l == '$' && a && characters.Length > 1 )
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                char[] expression = cadenaAux.ToCharArray();
                                Array.Reverse(expression);
                                int n;
                                Console.WriteLine("------------PARSING SUCCESS-----------");
                                if(int.TryParse(cadenaAux.ToString(), out result))
                                {
                                    Console.WriteLine("result of expression: {0}", result);
                                }
                                else
                                {
                                    foreach (char c in expression)//for each string character in the array
                                    {
                                        if (c != ' ' && c != '(' && c != ')')
                                        {
                                            if (int.TryParse(c.ToString(), out n))//if the character can be converted to a number (operand)
                                            {
                                                temporary = string.Concat(temporary, c.ToString());
                                            }
                                            if (c == '+')//handling of operators
                                            {
                                                string temp = Reverse(temporary);
                                                int.TryParse(temp, out n);
                                                IntStack.Push(n);//push current value onto the stack
                                                int x = Convert.ToInt32(IntStack.Pop());
                                                int y = Convert.ToInt32(IntStack.Pop());
                                                result = x + y;//evaluate the values popped from the stack
                                                IntStack.Push(result);//push current result onto the stack
                                                temporary = "";
                                            }
                                            if (c == '-')
                                            {
                                                string temp = Reverse(temporary);
                                                int.TryParse(temp, out n);
                                                IntStack.Push(n);
                                                int x = Convert.ToInt32(IntStack.Pop());
                                                int y = Convert.ToInt32(IntStack.Pop());
                                                result = y - x;
                                                IntStack.Push(result);
                                                temporary = "";
                                            }
                                            if (c == '*')
                                            {
                                                string temp = Reverse(temporary);
                                                int.TryParse(temp, out n);
                                                IntStack.Push(n);
                                                int x = Convert.ToInt32(IntStack.Pop());
                                                int y = Convert.ToInt32(IntStack.Pop());
                                                result = x * y;
                                                IntStack.Push(result);
                                                temporary = "";
                                            }
                                            if (c == '/')
                                            {
                                                string temp = Reverse(temporary);
                                                int.TryParse(temp, out n);
                                                IntStack.Push(n);
                                                int x = Convert.ToInt32(IntStack.Pop());
                                                int y = Convert.ToInt32(IntStack.Pop());
                                                result = y / x;
                                                IntStack.Push(result);
                                                temporary = "";
                                            }

                                        }

                                        if (c == ' ')
                                        {

                                            if (temporary != "")
                                            {
                                                string temp = Reverse(temporary);
                                                int.TryParse(temp, out n);
                                                IntStack.Push(n);
                                                temporary = "";
                                            }

                                        }
                                    }
                                    /*write the final result of the expression,
                                     * which is at the top of the stack, so we use Peek()*/
                                    Console.WriteLine("result of expression: {0}", IntStack.Peek());
                                }

                                
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("*************PARSING ERROR*************");
                            }
                            a = true;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("************Calculadora de Prefijo***********");
                            Console.WriteLine("Elija una opcion\n1.-Calculadora Enteros\n2.-Calculadora Flotantes\n3.-Calculadora Enteros y Flotantes\nSalir");
                            op = Console.ReadLine();
                        }
                        break;
                    case "2":
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Ingrese la Expresion Flotante");
                            String cadenaAux = Console.ReadLine().ToString();
                            String cadena = string.Concat(cadenaAux, "$");
                            Stack StackFloat = new Stack();
                            char[] characters = cadena.ToCharArray();
                            i = 0;
                            l = getChara(characters);
                            LEXPFloat(characters);
                            if (l == '$' && a && characters.Length > 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                char[] expression = cadenaAux.ToCharArray();
                                Array.Reverse(expression);
                                double n ;
                                int n1 ;
                                Console.WriteLine("------------PARSING SUCCESS-----------");
                                
                                if(double.TryParse(cadenaAux.ToString(), out result2))
                                {
                                    Console.WriteLine("result of expression: {0}", result2);
                                }
                                else
                                {
                                    foreach (char c in expression)//for each string character in the array
                                    {
                                        if (c != ' ' && c != '(' && c != ')')
                                        {
                                            if (int.TryParse(c.ToString(), out n1) || c == '.')//if the character can be converted to a number (operand)
                                            {
                                                temporary = string.Concat(temporary, c.ToString());
                                            }
                                            if (c == '+')//handling of operators
                                            {
                                                string temp = Reverse(temporary);
                                                double.TryParse(temp, out n);
                                                StackFloat.Push(n);//push current value onto the stack
                                                double x = Convert.ToDouble(StackFloat.Pop());
                                                double y = Convert.ToDouble(StackFloat.Pop());
                                                result2 = x + y;//evaluate the values popped from the stack
                                                StackFloat.Push(result2);//push current result onto the stack
                                                temporary = "";
                                            }
                                            if (c == '-')
                                            {
                                                string temp = Reverse(temporary);
                                                double.TryParse(temp, out n);
                                                StackFloat.Push(n);
                                                double x = Convert.ToDouble(StackFloat.Pop());
                                                double y = Convert.ToDouble(StackFloat.Pop());
                                                result2 = y - x;
                                                StackFloat.Push(result2);
                                                temporary = "";
                                            }
                                            if (c == '*')
                                            {
                                                string temp = Reverse(temporary);
                                                double.TryParse(temp, out n);
                                                StackFloat.Push(n);
                                                double x = Convert.ToDouble(StackFloat.Pop());
                                                double y = Convert.ToDouble(StackFloat.Pop());
                                                result2 = x * y;
                                                StackFloat.Push(result2);
                                                temporary = "";
                                            }
                                            if (c == '/')
                                            {
                                                string temp = Reverse(temporary);
                                                double.TryParse(temp, out n);
                                                StackFloat.Push(n);
                                                double x = Convert.ToDouble(StackFloat.Pop());
                                                double y = Convert.ToDouble(StackFloat.Pop());
                                                result2 = y / x;
                                                StackFloat.Push(result2);
                                                temporary = "";
                                            }
                                        }
                                        if (c == ' ')
                                        {
                                            if (temporary != "")
                                            {
                                                string temp = Reverse(temporary);
                                                double.TryParse(temp, out n);
                                                StackFloat.Push(n);
                                                temporary = "";
                                            }
                                        }
                                    }
                                    /*write the final result of the expression,
                                     * which is at the top of the stack, so we use Peek()*/
                                    Console.WriteLine("result of expression: {0}", StackFloat.Peek());
                                }
                                
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("*************PARSING ERROR*************");
                            }
                            a = true;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("************Calculadora de Prefijo***********");
                            Console.WriteLine("Elija una opcion\n1.-Calculadora Enteros\n2.-Calculadora Flotantes\n3.-Calculadora Enteros y Flotantes\nSalir");
                            op = Console.ReadLine();
                        }
                        break;
                    case "3":
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Ingrese la Expresion de Enteros y Flotantes");
                            String cadenaAux = Console.ReadLine().ToString();
                            String cadena = string.Concat(cadenaAux, "$");
                            Stack StackFloatInt = new Stack();
                            char[] characters = cadena.ToCharArray();
                            i = 0;
                            l = getChara(characters);
                            LEXPMix(characters);
                            if (l == '$' && a && characters.Length > 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                char[] expression = cadenaAux.ToCharArray();
                                Array.Reverse(expression);
                                double n;
                                int n1;
                                Console.WriteLine("------------PARSING SUCCESS-----------");

                                if (double.TryParse(cadenaAux.ToString(), out result2))
                                {
                                    Console.WriteLine("result of expression: {0}", result2);
                                }
                                else
                                {
                                    foreach (char c in expression)//for each string character in the array
                                    {
                                        if (c != ' ' && c != '(' && c != ')')
                                        {
                                            if (int.TryParse(c.ToString(), out n1) || c == '.')//if the character can be converted to a number (operand)
                                            {
                                                temporary = string.Concat(temporary, c.ToString());
                                            }
                                            if (c == '+')//handling of operators
                                            {
                                                string temp = Reverse(temporary);
                                                double.TryParse(temp, out n);
                                                StackFloatInt.Push(n);//push current value onto the stack
                                                double x = Convert.ToDouble(StackFloatInt.Pop());
                                                double y = Convert.ToDouble(StackFloatInt.Pop());
                                                result2 = x + y;//evaluate the values popped from the stack
                                                StackFloatInt.Push(result2);//push current result onto the stack
                                                temporary = "";
                                            }
                                            if (c == '-')
                                            {
                                                string temp = Reverse(temporary);
                                                double.TryParse(temp, out n);
                                                StackFloatInt.Push(n);
                                                double x = Convert.ToDouble(StackFloatInt.Pop());
                                                double y = Convert.ToDouble(StackFloatInt.Pop());
                                                result2 = y - x;
                                                StackFloatInt.Push(result2);
                                                temporary = "";
                                            }
                                            if (c == '*')
                                            {
                                                string temp = Reverse(temporary);
                                                double.TryParse(temp, out n);
                                                StackFloatInt.Push(n);
                                                double x = Convert.ToDouble(StackFloatInt.Pop());
                                                double y = Convert.ToDouble(StackFloatInt.Pop());
                                                result2 = x * y;
                                                StackFloatInt.Push(result2);
                                                temporary = "";
                                            }
                                            if (c == '/')
                                            {
                                                string temp = Reverse(temporary);
                                                double.TryParse(temp, out n);
                                                StackFloatInt.Push(n);
                                                double x = Convert.ToDouble(StackFloatInt.Pop());
                                                double y = Convert.ToDouble(StackFloatInt.Pop());
                                                result2 = y / x;
                                                StackFloatInt.Push(result2);
                                                temporary = "";
                                            }
                                        }
                                        if (c == ' ')
                                        {
                                            if (temporary != "")
                                            {
                                                string temp = Reverse(temporary);
                                                double.TryParse(temp, out n);
                                                StackFloatInt.Push(n);
                                                temporary = "";
                                            }
                                        }
                                    }
                                    /*write the final result of the expression,
                                     * which is at the top of the stack, so we use Peek()*/
                                    Console.WriteLine("result of expression: {0}", StackFloatInt.Peek());
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("*************PARSING ERROR*************");
                            }
                            a = true;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("************Calculadora de Prefijo***********");
                            Console.WriteLine("Elija una opcion\n1.-Calculadora Enteros\n2.-Calculadora Flotantes\n3.-Calculadora Enteros y Flotantes\nSalir");
                            op = Console.ReadLine();
                        }
                        break;
                    default:
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Opcion Incorrecta");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("************Calculadora de Prefijo***********");
                            Console.WriteLine("Elija una opcion\n1.-Calculadora Enteros\n2.-Calculadora Flotantes\n3.-Calculadora Enteros y Flotantes\nSalir");
                            op = Console.ReadLine();
                        }
                        break;

                }
            } while (op != "4");

        }
        public static void LEXP(char[] caracteres)
        {
            if (a)
            {
                if (l == '(')
                {
                    Match('(', caracteres);
                    Op(caracteres);
                    LEXP(caracteres);
                    l = getChara(caracteres);
                    LEXP(caracteres);
                    Match(')', caracteres);
                }
                else
                {
                    Numero(caracteres);
                }
            }
        }
        public static void Numero(char[] caracteres)
        {
            if (a)
            {
                if (l == '0')
                {
                    Match('0', caracteres);
                }
                else if (l == '1')
                {
                    Match('1', caracteres);
                    N(caracteres);
                }
                else if (l == '2')
                {
                    Match('2', caracteres);
                    N(caracteres);
                }
                else if (l == '3')
                {
                    Match('3', caracteres);
                    N(caracteres);
                }
                else if (l == '4')
                {
                    Match('4', caracteres);
                    N(caracteres);
                }
                else if (l == '5')
                {
                    Match('5', caracteres);
                    N(caracteres);
                }
                else if (l == '6')
                {
                    Match('6', caracteres);
                    N(caracteres);
                }
                else if (l == '7')
                {
                    Match('7', caracteres);
                    N(caracteres);
                }
                else if (l == '8')
                {
                    Match('8', caracteres);
                    N(caracteres);
                }
                else if (l == '9')
                {
                    Match('9', caracteres);
                    N(caracteres);
                }
            }
        }
        public static void N(char[] caracteres)
        {
            if (a)
            {
                if (l == '0')
                {
                    Match('0', caracteres);
                    N(caracteres);
                }
                else if (l == '1')
                {
                    Match('1', caracteres);
                    N(caracteres);
                }
                else if (l == '2')
                {
                    Match('2', caracteres);
                    N(caracteres);
                }
                else if (l == '3')
                {
                    Match('3', caracteres);
                    N(caracteres);
                }
                else if (l == '4')
                {
                    Match('4', caracteres);
                    N(caracteres);
                }
                else if (l == '5')
                {
                    Match('5', caracteres);
                    N(caracteres);
                }
                else if (l == '6')
                {
                    Match('6', caracteres);
                    N(caracteres);
                }
                else if (l == '7')
                {
                    Match('7', caracteres);
                    N(caracteres);
                }
                else if (l == '8')
                {
                    Match('8', caracteres);
                    N(caracteres);
                }
                else if (l == '9')
                {
                    Match('9', caracteres);
                    N(caracteres);
                }
                else
                {
                    return;
                }
            }

        }
        public static void Op(char[] caracteres)
        {
            if (a)
            {
                if (l == '+')
                {
                    Match('+', caracteres);
                }

                else if (l == '-')
                {
                    Match('-', caracteres);
                }
                else if (l == '*')
                {
                    Match('*', caracteres);
                }
                else if (l == '/')
                {
                    Match('/', caracteres);
                }
                else if (l == '%')
                {
                    Match('%', caracteres);
                }
                else if (l == '^')
                {
                    Match('^', caracteres);
                }
                else
                {
                    a = false;
                }
            }
        }
        public static void Match(char t, char[] caracteres)
        {
            if (a)
            {
                if (l == t)
                {
                    l = getChara(caracteres);
                }
                else
                {
                    a = false;
                }
            }
        }
        public static char getChara(char[] carac)
        {
            char aux = ' ';
            if (a)
            {
                aux = carac[i];
                i = i + 1;
                return aux;
            }
            else
            {
                return aux;
            }
        }

        public static void LEXPFloat(char[] caracteres)
        {
            if (a)
            {
                if (l == '(')
                {
                    Match('(', caracteres);
                    Op(caracteres);
                    LEXPFloat(caracteres);
                    l = getChara(caracteres);
                    LEXPFloat(caracteres);
                    Match(')', caracteres);
                }
                else
                {
                    Double(caracteres);
                }
            }
        }
        public static void Double(char[] caracteres)
        {
            if (a)
            {
                Numero(caracteres);
                Match('.', caracteres);
                Numero(caracteres);
            }
        }
        public static void LEXPMix(char[] caracteres)
        {
            if (a)
            {
                if (l == '(')
                {
                    Match('(', caracteres);
                    Op(caracteres);
                    LEXPMix(caracteres);
                    l = getChara(caracteres);
                    LEXPMix(caracteres);
                    Match(')', caracteres);
                }
                else
                {
                    NumeroMix(caracteres);
                }
            }
        }
        public static void NumeroMix(char[] caracteres)
        {
            if (a)
            {
                if (l == '0')
                {
                    Match('0', caracteres);
                }
                else if (l == '1')
                {
                    Match('1', caracteres);
                    N(caracteres);
                }
                else if (l == '2')
                {
                    Match('2', caracteres);
                    N(caracteres);
                }
                else if (l == '3')
                {
                    Match('3', caracteres);
                    N(caracteres);
                }
                else if (l == '4')
                {
                    Match('4', caracteres);
                    N(caracteres);
                }
                else if (l == '5')
                {
                    Match('5', caracteres);
                    N(caracteres);
                }
                else if (l == '6')
                {
                    Match('6', caracteres);
                    N(caracteres);
                }
                else if (l == '7')
                {
                    Match('7', caracteres);
                    N(caracteres);
                }
                else if (l == '8')
                {
                    Match('8', caracteres);
                    N(caracteres);
                }
                else if (l == '9')
                {
                    Match('9', caracteres);
                    N(caracteres);
                }
                if (l == '.')
                {
                    Match('.', caracteres);
                    Decimal(caracteres);
                }

            }

        }

        public static void Decimal(char[] caracteres)
        {
            if (a)
            {
                if (l == '0')
                {
                    Match('0', caracteres);
                }
                else if (l == '1')
                {
                    Match('1', caracteres);
                    D(caracteres);
                }
                else if (l == '2')
                {
                    Match('2', caracteres);
                    D(caracteres);
                }
                else if (l == '3')
                {
                    Match('3', caracteres);
                    D(caracteres);
                }
                else if (l == '4')
                {
                    Match('4', caracteres);
                    D(caracteres);
                }
                else if (l == '5')
                {
                    Match('5', caracteres);
                    D(caracteres);
                }
                else if (l == '6')
                {
                    Match('6', caracteres);
                    D(caracteres);
                }
                else if (l == '7')
                {
                    Match('7', caracteres);
                    D(caracteres);
                }
                else if (l == '8')
                {
                    Match('8', caracteres);
                    D(caracteres);
                }
                else if (l == '9')
                {
                    Match('9', caracteres);
                    D(caracteres);
                }

            }

        }
        public static void D(char[] caracteres)
        {
            if (a)
            {
                if (l == '0')
                {
                    Match('0', caracteres);
                    D(caracteres);
                }
                else if (l == '1')
                {
                    Match('1', caracteres);
                    D(caracteres);
                }
                else if (l == '2')
                {
                    Match('2', caracteres);
                    D(caracteres);
                }
                else if (l == '3')
                {
                    Match('3', caracteres);
                    D(caracteres);
                }
                else if (l == '4')
                {
                    Match('4', caracteres);
                    D(caracteres);
                }
                else if (l == '5')
                {
                    Match('5', caracteres);
                    D(caracteres);
                }
                else if (l == '6')
                {
                    Match('6', caracteres);
                    D(caracteres);
                }
                else if (l == '7')
                {
                    Match('7', caracteres);
                    D(caracteres);
                }
                else if (l == '8')
                {
                    Match('8', caracteres);
                    D(caracteres);
                }
                else if (l == '9')
                {
                    Match('9', caracteres);
                    D(caracteres);
                }
                else
                {
                    return;
                }
            }

        }
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

    }
}
