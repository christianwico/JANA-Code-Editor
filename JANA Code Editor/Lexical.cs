﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JANA_Code_Editor
{
    public class Lexical
    {
        // INSTANCE PROPERTIES
        private string output { get; set; }
        private string current { get; set; }
        private int currLine { get; set; }
        private int currColumn { get; set; }
        private char delimiter { get; set; }
        private bool hasError { get; set; }
        private bool hasLookahead { get; set; }
        private bool isDelimited { get; set; }
        private bool isSeperator { get; set; }
        private bool wasSymbol { get; set; }
        private char[] code { get; set; }
        private bool isFound { get; set; }
        private string symbol { get; set; }
        private int rows { get; set; }

        // Regular Expressions
        private string space = "\\s";
        private string paren = "\\(";
        private string hyphen = "\\-";
        private string semic = ";";
        private string newline = "\\r|\\n";
        private string zero = "0";
        private string und = "_";
        private string colon = ":";
        private string lowalpha = "[a-z]";
        private string upalpha = "[A-Z]";
        private string digit = "[1-9]";
        private string ASCII = ".";
        private string otherSY1 = "\\+";
        private string otherSY2 = "\\-|>";
        private string relop = "=|!";
        private string delRW_1 = ";|\\s";
        private string delRW_2 = ":|\\s|\\r";
        private string delRW_3 = "\\{|\\s|\\r";
        private string delRW_4 = "(|\\s)";
        private string delSY_1 = "\\s|[1-9]";
        private string delSY_2 = "\\s|[A-Z]|[a-z]";
        private string delSY_3 = "\\s|[A-Z]|[a-z]|[1-9]";
        private string delSY_4 = "\\s|.";
        private string delSY_5 = ";|\\r";
        private string delSY_6 = "\\s|[A-Z]|[a-z]|[1-9]|.";
        private string delSY_7 = "\\s|[A-Z]|[a-z]|[1-9]|.|;|\\r";
        private string delSY_8 = "\\n|";
        private string delSY_9 = "\\s|.|;|\\r|";
        private string delSY_10 = "\\s|.|;";
        private string delSY_11 = ":|\\s|\\r||\"";
        private string delid = ";|\\s|=|\\[|";
        private string delit = ";|\\s|\\.";
        private string delch = ";|\\s|'";
        private string delstr = ";|\\s|\"";

        // Identifiers
        private string id = "([a-z]|[A-Z])([a-z]|[A-Z]|[0-9]|_){0,9}";
        private string comment_line = "//";
        private string comment_block = "^(/\\*).*(\\*/)$";

        // Data Values
        private string intType = "^(~)*[1-9][0-9]{0,9}$";
        private string floatType = "^(~|[1-9])[0-9]{0,9}\\.[0-9]{0,10}";
        private string charType = "'.'";
        private string stringType = "^(\").*(\")$";

        // ALL OPERATORS
        private string operators = "\\+|\\-|/|%|\\*\\^|~|@@|\\$\\$|\\$|=|==|==!|>>|<<|>>=|" +
            "<<=|\\+\\+|\\-\\-|\\(|\\)|\\{|\\}|\\[|\\]|-!|\\-\\->|;|:";

        // SEPERATORS
        private string seperators = "\\s|\\r|,";

        // DELIMITERS
        private string delimiters = "\\\"|'";

        /*
        // Logical Operators
        private string logical_and = "@@";
        private string logical_or = "\\|\\|";

        // Relational Operators
        private string equal = "==";
        private string not_equal = "==!";
        private string gt = ">>";
        private string lt = "<<";
        private string gt_equal = ">>=";
        private string lt_equal = "<<=";

        // Other Symbols
        private string increment = "\\+\\+";
        private string decrement = "\\-\\-";

        // Arithmetic Operators
        private string add = "\\+";
        private string subtract = "\\-";
        private string divide = "/";
        //private string wut = "\\";
        private string modulo = "%";
        private string multiply = "\\*";
        private string power = "\\^";
        private string negate = "~";

        private string comma = ",";
        */

        int c = -1;

        // ENTRY POINT.
        public string Start(string[] input)
        {
            code = frmMain.Self.document.Text.ToCharArray();

            rows = 0;

            while (c < code.Length) scan();

            return output;
        }

        private void scan()
        {
            Regex rgx1, rgx2;
            Regex rgxId = new Regex(id);
            isFound = false;
            symbol = "";
            
            try
            {
                // 0
                if (code[++c] == 'a')
                {
                    // 1
                    symbol += code[c];
                    if (code[++c] == 't')
                    {
                        // 2
                        symbol += code[c];
                        if (code[++c] == 't')
                        {
                            // 3
                            symbol += code[c];
                            if (code[++c] == 'e')
                            {
                                // 4
                                symbol += code[c];
                                if (code[++c] == 'm')
                                {
                                    // 5
                                    symbol += code[c];
                                    if (code[++c] == 'p')
                                    {
                                        // 6
                                        symbol += code[c];
                                        if (code[++c] == 't')
                                        {
                                            // 7
                                            symbol += code[c];
                                            rgx1 = new Regex(delRW_3);
                                            if (rgx1.IsMatch(code[++c].ToString()))
                                            {
                                                // 8+
                                                rows++;
                                                isFound = true;
                                                frmMain.Self.dGridResults.Rows.Add("attempt", "attempt");
                                            } else if (!rgxId.IsMatch(code[c].ToString())) {
                                                isFound = true;
                                                rows++;
                                                output += "[ERROR] Invalid use of reserved word 'attempt'.\r\n";
                                                hasError = true;
                                                frmMain.Self.dGridResults.Rows.Add("attempt", "invalid");
                                                frmMain.Self.dGridResults.Rows[rows - 1].DefaultCellStyle.BackColor =
                                                    System.Drawing.Color.Red;
                                                frmMain.Self.dGridResults.Rows[rows - 1].DefaultCellStyle.ForeColor =
                                                    System.Drawing.Color.White;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                } else if (code[c] == 'b')
                {
                    // 9
                    symbol += code[c];
                    if (code[++c] == 'o')
                    {
                        // 10
                        symbol += code[c];
                        if (code[++c] == 'o')
                        {
                            // 11
                            symbol += code[c];
                            if (code[++c] == 'l')
                            {
                                // 12
                                symbol += code[c];
                                if (code[++c] == 'e')
                                {
                                    // 13
                                    symbol += code[c];
                                    if (code[++c] == 'a')
                                    {
                                        // 14
                                        symbol += code[c];
                                        if (code[++c] == 'n')
                                        {
                                            // 15
                                            symbol += code[c];
                                            rgx1 = new Regex(space);
                                            if (rgx1.IsMatch(code[++c].ToString()))
                                            {
                                                // 16+
                                                rows++;
                                                isFound = true;
                                                frmMain.Self.dGridResults.Rows.Add("boolean", "boolean");
                                            } else if (!rgxId.IsMatch(code[c].ToString()))
                                            {
                                                rows++;
                                                isFound = true;
                                                output += "[ERROR] Invalid use of reserved word 'boolean'.\r\n";
                                                hasError = true;
                                                frmMain.Self.dGridResults.Rows.Add("boolean", "invalid");
                                                frmMain.Self.dGridResults.Rows[rows - 1].DefaultCellStyle.BackColor =
                                                    System.Drawing.Color.Red;
                                                frmMain.Self.dGridResults.Rows[rows - 1].DefaultCellStyle.ForeColor =
                                                    System.Drawing.Color.White;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                } else if (code[c] == 'c')
                {
                    // 17
                    symbol += code[c];
                    if (code[++c] == 'h')
                    {
                        // 18
                        symbol += code[c];
                        if (code[++c] == 'a')
                        {
                            // 19
                            symbol += code[c];
                            if (code[++c] == 'r')
                            {
                                // 20
                                symbol += code[c];
                                rgx1 = new Regex(space);
                                if (rgx1.IsMatch(code[++c].ToString()))
                                {
                                    // 21+
                                    rows++;
                                    isFound = true;
                                    frmMain.Self.dGridResults.Rows.Add("char", "char");
                                } else if (!rgxId.IsMatch(code[c].ToString()))
                                {
                                    rows++;
                                    isFound = true;
                                    output += "[ERROR] Invalid use of reserved word 'char'.\r\n";
                                    hasError = true;
                                    frmMain.Self.dGridResults.Rows.Add("char", "invalid");
                                    frmMain.Self.dGridResults.Rows[rows - 1].DefaultCellStyle.BackColor =
                                                    System.Drawing.Color.Red;
                                    frmMain.Self.dGridResults.Rows[rows - 1].DefaultCellStyle.ForeColor =
                                        System.Drawing.Color.White;
                                }
                            }
                        } else if (code[c] == 'o')
                        {
                            // 22
                            symbol += code[c];
                            if (code[++c] == 'i')
                            {
                                // 23
                                symbol += code[c];
                                if (code[++c] == 'c')
                                {
                                    // 24
                                    symbol += code[c];
                                    if (code[++c] == 'e')
                                    {
                                        // 25
                                        symbol += code[c];
                                        rgx1 = new Regex(delRW_2);
                                        if (rgx1.IsMatch(code[++c].ToString()))
                                        {
                                            // 26+
                                            rows++;
                                            isFound = true;
                                            frmMain.Self.dGridResults.Rows.Add("choice", "choice");
                                        } else if (!rgxId.IsMatch(code[c].ToString()))
                                        {
                                            isFound = true;
                                            rows++;
                                            output += "[ERROR] Invalid use of reserved word 'choice'.\r\n";
                                            hasError = true;
                                            frmMain.Self.dGridResults.Rows.Add("choice", "invalid");
                                            frmMain.Self.dGridResults.Rows[rows - 1].DefaultCellStyle.BackColor =
                                                    System.Drawing.Color.Red;
                                            frmMain.Self.dGridResults.Rows[rows - 1].DefaultCellStyle.ForeColor =
                                                System.Drawing.Color.White;
                                        }
                                    }
                                }
                            }
                        }
                    } else if (code[c] == 'l')
                    {
                        // 27
                        symbol += code[c];
                        if (code[++c] == 'e')
                        {
                            // 28
                            symbol += code[c];
                            if (code[++c] == 'a')
                            {
                                // 29
                                symbol += code[c];
                                if (code[++c] == 'n')
                                {
                                    // 30
                                    symbol += code[c];
                                    rgx1 = new Regex(paren);
                                    if (rgx1.IsMatch(code[++c].ToString()))
                                    {
                                        // 31+
                                        rows++;
                                        isFound = true;
                                        frmMain.Self.dGridResults.Rows.Add("clean", "clean");
                                    } else if (!rgxId.IsMatch(code[c].ToString()))
                                    {
                                        rows++;
                                        isFound = true;
                                        output += "[ERROR] Invalid use of reserved word 'clean'.\r\n";
                                        hasError = true;
                                        frmMain.Self.dGridResults.Rows.Add("clean", "invalid");
                                        frmMain.Self.dGridResults.Rows[rows - 1].DefaultCellStyle.BackColor =
                                                    System.Drawing.Color.Red;
                                        frmMain.Self.dGridResults.Rows[rows - 1].DefaultCellStyle.ForeColor =
                                            System.Drawing.Color.White;
                                    }
                                }
                            }
                        }
                    }
                } else if (code[c] == 'd')
                {
                    // 32
                    symbol += code[c];
                    if (code[++c] == 'o')
                    {
                        // 33
                        symbol += code[c];
                        rgx1 = new Regex(delRW_3);
                        if (rgx1.IsMatch(code[++c].ToString()))
                        {
                            // 34
                            rows++;
                            isFound = true;
                            frmMain.Self.dGridResults.Rows.Add("do", "do");
                        } else if (!rgxId.IsMatch(code[c].ToString()))
                        {
                            rows++;
                            isFound = true;
                            output += "[ERROR] Invalid use of reserved word 'do'.\r\n";
                            hasError = true;
                            frmMain.Self.dGridResults.Rows.Add("do", "invalid");
                            frmMain.Self.dGridResults.Rows[rows - 1].DefaultCellStyle.BackColor =
                                System.Drawing.Color.Red;
                            frmMain.Self.dGridResults.Rows[rows - 1].DefaultCellStyle.ForeColor =
                                System.Drawing.Color.White;
                        }
                    }
                } else if (code[c] == 'e')
                {
                    // 35
                    symbol += code[c];
                    if (code[++c] == 'l')
                    {
                        // 36
                        symbol += code[c];
                        if (code[++c] == 's')
                        {
                            // 37
                            symbol += code[c];
                            if (code[++c] == 'e')
                            {
                                // 38
                                symbol += code[c];
                                rgx1 = new Regex(delRW_3);
                                if (code[++c] == 'i')
                                {
                                    // 40
                                    symbol += code[c];
                                    if (code[++c] == 'f')
                                    {
                                        // 41
                                        symbol += code[c];
                                        if (rgx1.IsMatch(code[++c].ToString()))
                                        {
                                            // 42+
                                            rows++;
                                            isFound = true;
                                            frmMain.Self.dGridResults.Rows.Add("elseif", "elseif");
                                        } else if (!rgxId.IsMatch(code[c].ToString()))
                                        {
                                            rows++;
                                            isFound = true;
                                            output += "[ERROR] Invalid use of reserved word 'elseif'.\r\n";
                                            hasError = true;
                                            frmMain.Self.dGridResults.Rows.Add("elseif", "invalid");
                                            frmMain.Self.dGridResults.Rows[rows - 1].DefaultCellStyle.BackColor =
                                                    System.Drawing.Color.Red;
                                            frmMain.Self.dGridResults.Rows[rows - 1].DefaultCellStyle.ForeColor =
                                                System.Drawing.Color.White;
                                        }
                                    }
                                } else if (rgx1.IsMatch(code[c].ToString()))
                                {
                                    // 39+
                                    rows++;
                                    isFound = true;
                                    frmMain.Self.dGridResults.Rows.Add("else", "else");
                                } else if (!rgxId.IsMatch(code[c].ToString()))
                                {
                                    rows++;
                                    isFound = true;
                                    output += "[ERROR] Invalid use of reserved word 'else'.\r\n";
                                    hasError = true;
                                    frmMain.Self.dGridResults.Rows.Add("else", "invalid");
                                    frmMain.Self.dGridResults.Rows[rows - 1].DefaultCellStyle.BackColor =
                                                    System.Drawing.Color.Red;
                                    frmMain.Self.dGridResults.Rows[rows - 1].DefaultCellStyle.ForeColor =
                                        System.Drawing.Color.White;
                                }
                            }
                        }
                    } else if (code[c] == 'x')
                    {
                        // 43
                        symbol += code[c];
                        if (code[++c] == 'i')
                        {
                            // 44
                            symbol += code[c];
                            if (code[++c] == 't')
                            {
                                // 45
                                symbol += code[c];
                                if (code[++c] == '(')
                                {
                                    // 46
                                    symbol += code[c];
                                    if (code[++c] == ')')
                                    {
                                        // 47
                                        symbol += code[c];
                                        rgx1 = new Regex(delRW_1);
                                        if (rgx1.IsMatch(code[++c].ToString()))
                                        {
                                            // 48+
                                            rows++;
                                            isFound = true;
                                            frmMain.Self.dGridResults.Rows.Add("exit", "exit");
                                        } else if (!rgxId.IsMatch(code[c].ToString()))
                                        {
                                            rows++;
                                            isFound = true;
                                            output += "[ERROR] Invalid use of reserved word 'exit'.\r\n";
                                            hasError = true;
                                            frmMain.Self.dGridResults.Rows.Add("exit", "invalid");
                                            frmMain.Self.dGridResults.Rows[rows - 1].DefaultCellStyle.BackColor =
                                                    System.Drawing.Color.Red;
                                            frmMain.Self.dGridResults.Rows[rows - 1].DefaultCellStyle.ForeColor =
                                                System.Drawing.Color.White;
                                        }
                                    }
                                }
                            }
                        }
                    }
                } else if (code[c] == 'f')
                {
                    // 49
                    symbol += code[c];
                    if (code[++c] == 'a')
                    {
                        // 50
                        symbol += code[c];
                        if (code[++c] == 'l')
                        {
                            // 51
                            symbol += code[c];
                            if (code[++c] == 'l')
                            {
                                // 52
                                symbol += code[c];
                                rgx1 = new Regex(delRW_2);
                                if (rgx1.IsMatch(code[++c].ToString()))
                                {
                                    // 53+
                                    rows++;
                                    isFound = true;
                                    frmMain.Self.dGridResults.Rows.Add("fall", "fall");
                                } else if (!rgxId.IsMatch(code[c].ToString()))
                                {
                                    rows++;
                                    isFound = true;
                                    output += "[ERROR] Invalid use of reserved word 'fall'.\r\n";
                                    hasError = true;
                                    frmMain.Self.dGridResults.Rows.Add("fall", "invalid");
                                    frmMain.Self.dGridResults.Rows[rows - 1].DefaultCellStyle.BackColor =
                                                    System.Drawing.Color.Red;
                                    frmMain.Self.dGridResults.Rows[rows - 1].DefaultCellStyle.ForeColor =
                                        System.Drawing.Color.White;
                                }
                            } else if (code[c] == 's')
                            {
                                // 54
                                symbol += code[c];
                                if (code[++c] == 'e')
                                {
                                    // 55
                                    symbol += code[c];
                                    rgx1 = new Regex(delRW_1);
                                    if (rgx1.IsMatch(code[++c].ToString()))
                                    {
                                        // 56+
                                        rows++;
                                        isFound = true;
                                        frmMain.Self.dGridResults.Rows.Add("false", "false");
                                    }
                                    else if (!rgxId.IsMatch(code[c].ToString()))
                                    {
                                        rows++;
                                        isFound = true;
                                        output += "[ERROR] Invalid use of reserved word 'false'.\r\n";
                                        hasError = true;
                                        frmMain.Self.dGridResults.Rows.Add("false", "invalid");
                                        frmMain.Self.dGridResults.Rows[rows - 1].DefaultCellStyle.BackColor =
                                                    System.Drawing.Color.Red;
                                        frmMain.Self.dGridResults.Rows[rows - 1].DefaultCellStyle.ForeColor =
                                            System.Drawing.Color.White;
                                    }
                                }
                            }
                        }
                    }
                } else if (code[c] == 'g')
                {
                    // 57
                    symbol += code[c];
                    if (code[++c] == 'e')
                    {
                        // 58
                        symbol += code[c];
                        if (code[++c] == 't')
                        {
                            // 59
                            symbol += code[c];
                            rgx1 = new Regex(hyphen);
                            if (rgx1.IsMatch(code[++c].ToString()))
                            {
                                // 60+
                                rows++;
                                isFound = true;
                                frmMain.Self.dGridResults.Rows.Add("get", "get");
                            } else if (!rgxId.IsMatch(code[c].ToString()))
                            {
                                rows++;
                                isFound = true;
                                output += "[ERROR] Invalid use of reserved word 'get'.\r\n";
                                hasError = true;
                                frmMain.Self.dGridResults.Rows.Add("get", "invalid");
                                frmMain.Self.dGridResults.Rows[rows - 1].DefaultCellStyle.BackColor =
                                                    System.Drawing.Color.Red;
                                frmMain.Self.dGridResults.Rows[rows - 1].DefaultCellStyle.ForeColor =
                                    System.Drawing.Color.White;
                            }
                        }
                    }
                } else if (code[c] == 'h')
                {
                    // 61
                    symbol += code[c];
                    if (code[++c] == 'a')
                    {
                        // 62
                        symbol += code[c];
                        if (code[++c] == 'n')
                        {
                            // 63
                            symbol += code[c];
                            if (code[++c] == 'd')
                            {
                                // 64
                                symbol += code[c];
                                if (code[++c] == 'l')
                                {
                                    // 65
                                    symbol += code[c];
                                    if (code[++c] == 'e')
                                    {
                                        // 66
                                        symbol += code[c];
                                        rgx1 = new Regex(delRW_3);
                                        if (rgx1.IsMatch(code[++c].ToString()))
                                        {
                                            // 67+
                                            rows++;
                                            isFound = true;
                                            frmMain.Self.dGridResults.Rows.Add("handle", "handle");
                                        } else if (!rgxId.IsMatch(code[c].ToString()))
                                        {
                                            rows++;
                                            isFound = true;
                                            output += "[ERROR] Invalid use of reserved word 'handle'.\r\n";
                                            hasError = true;
                                            frmMain.Self.dGridResults.Rows.Add("handle", "invalid");
                                            frmMain.Self.dGridResults.Rows[rows - 1].DefaultCellStyle.BackColor =
                                                    System.Drawing.Color.Red;
                                            frmMain.Self.dGridResults.Rows[rows - 1].DefaultCellStyle.ForeColor =
                                                System.Drawing.Color.White;
                                        }
                                    }
                                }
                            }
                        }
                    }
                } else if (code[c] == 'i')
                {
                    // 68
                    symbol += code[c];
                    if (code[++c] == 'f')
                    {
                        // 69
                        symbol += code[c];
                        rgx1 = new Regex(delRW_4);
                        if (rgx1.IsMatch(code[++c].ToString()))
                        {
                            // 70+
                            rows++;
                            isFound = true;
                            frmMain.Self.dGridResults.Rows.Add("if", "if");
                        } else if (!rgxId.IsMatch(code[c].ToString()))
                        {
                            rows++;
                            isFound = true;
                            output += "[ERROR] Invalid use of reserved word 'if'.\r\n";
                            hasError = true;
                            frmMain.Self.dGridResults.Rows.Add("if", "invalid");
                            frmMain.Self.dGridResults.Rows[rows - 1].DefaultCellStyle.BackColor =
                                                    System.Drawing.Color.Red;
                            frmMain.Self.dGridResults.Rows[rows - 1].DefaultCellStyle.ForeColor =
                                System.Drawing.Color.White;
                        }
                    }
                }

                if (!isFound)
                {
                    rgx1 = new Regex(delid);
                    rgx2 = new Regex("[a-z]|[A-Z]|[0-9]|_");
                    int size = symbol.Length;

                    while (true)
                    {
                        if (rgx2.IsMatch(code[c].ToString()))
                        {
                            symbol += code[c];
                            size++;
                            c++;
                        } else break;
                    }

                    if (size > 10)
                    {
                        output += "[ERROR] Identifier '" + symbol + "' is beyond the " + 
                            "prescribed identifier length (10 chars).\r\n";
                        hasError = true;
                        frmMain.Self.dGridResults.Rows.Add(symbol, "invalid");
                        frmMain.Self.dGridResults.Rows[rows - 1].DefaultCellStyle.BackColor =
                                                System.Drawing.Color.Red;
                        frmMain.Self.dGridResults.Rows[rows - 1].DefaultCellStyle.ForeColor =
                            System.Drawing.Color.White;
                    } else if (rgxId.IsMatch(code[c].ToString()))
                    {
                        rows++;
                        isFound = true;
                        frmMain.Self.dGridResults.Rows.Add(symbol, "identifier");
                    } else
                    {
                        rows++;
                        isFound = true;
                        output += "[ERROR] Invalid use of identifier '" + symbol + "'.\r\n";
                        hasError = true;
                        frmMain.Self.dGridResults.Rows.Add(symbol, "invalid");
                        frmMain.Self.dGridResults.Rows[rows - 1].DefaultCellStyle.BackColor =
                                                System.Drawing.Color.Red;
                        frmMain.Self.dGridResults.Rows[rows - 1].DefaultCellStyle.ForeColor =
                            System.Drawing.Color.White;
                    }
                }
            } catch
            {

            }
        }
    }
}