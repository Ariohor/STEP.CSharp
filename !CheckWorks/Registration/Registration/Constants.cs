using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWork
{
    public class Constants
    {
        public const int MAX_SIZE_PHONE_NUMBER = 15; // 8 708 668 18 21 - 15
        public const int MIN_SIZE_PHONE_NUMBER = 11; // 87086681821     - 11 

        public const int MIN_SIZE_PASSWORD = 8;

        public const char EMAIL_SIGN = '@';
        public const char DOT = '.';

        public const int MIN_COUNT_LETTERS_AFTER_LAST_DOT = 2;
        public const int MAX_COUNT_LETTERS_AFTER_LAST_DOT = 4;
        public const int MIN_COUNT_LETTERS_BETWEEN_EMAIL_SIGN_LAST_DOT = 4;
    }
}
