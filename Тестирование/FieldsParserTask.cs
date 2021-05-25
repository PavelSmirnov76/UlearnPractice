using System.Collections.Generic;
using System.Text;

namespace TableParser
{
  
    public class FieldsParserTask
    {
        public static List<Token> ParseLine(string line)
        {
            var tokenList = new List<Token>();

            for (int i = GetIndexNextToToken(line, new Token("", 0, 0));
                                             i < line.Length; 
                                             i = GetIndexNextToToken(line, tokenList[tokenList.Count - 1]))
                if (line[i] == '"' || line[i] == '\'')
                    tokenList.Add(ReadQuotedField(line, i));
                else
                    if (line[i] != ' ')
                        tokenList.Add(ReadField(line, i));
            
            return tokenList;
        }

        private static int GetIndexNextToToken(string list, Token token)
        {
            int startIndexNextToken = token.GetIndexNextToToken();
            while(startIndexNextToken < list.Length && list[startIndexNextToken] == ' ')
            {
                startIndexNextToken++;
            }
            return startIndexNextToken;
        }

        private static Token ReadField(string line, int startIndex)
        {
            var tokenValue = new StringBuilder();
            var tokenLength = 0;

            while (startIndex + tokenLength < line.Length && line[startIndex + tokenLength] != ' '
                                                          && line[startIndex + tokenLength] != '"'
                                                          && line[startIndex + tokenLength] != '\'')
            {
                tokenValue.Append(line[startIndex + tokenLength]);
                tokenLength++;
            }

            return new Token(tokenValue.ToString(), startIndex, tokenLength);
        }

        public static Token ReadQuotedField(string line, int startIndex)
        {
            return QuotedFieldTask.ReadQuotedField(line, startIndex);
        }
    }
}