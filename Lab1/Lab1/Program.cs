using System;

namespace Lab1
{
    class Card
    {
        private string bookTitle;      //the title of the book
        private string bookAuthor;     //the author of the book
        private int booksOut;          //the general num of books out
        private DateTime dateOut;      //the date of giving the book to the client
        private DateTime dateIn;       //the date of bringing back the book

        /// <summary>
        /// Constructor by default
        /// </summary>
        public Card()
        {
            bookTitle = "Deafualt";
            bookAuthor = "Default";
            booksOut = 0;
            dateOut = new DateTime(1970, 1, 1);     //the common default time
            dateIn = new DateTime(1000, 1, 1);      //nullable time for the current program
        }

        /// <summary>
        /// Constructor for the input data
        /// </summary>
        /// <param name="title">Title of the book</param>
        /// <param name="author">Author of the book</param>
        /// <param name="outs">The number of books out</param>
        /// <param name="dOut">The date the client brought out the book</param>
        /// <param name="dIn">The date (if it exists) the client brought book back</param>
        public Card(string title, string author, int outs, DateTime dOut, DateTime dIn)
        {
            bookTitle = title;
            bookAuthor = author;
            booksOut = outs;
            dateOut = dOut;

            if (dIn > dOut)                                                             //if the day of bringig back was earlier than out, the back is nullabe
                dateIn = dIn;
            else
                dateIn = DateTime.Parse("1/1/1000");
        }

        /// <summary>
        /// Calculates the number of days between out and in
        /// </summary>
        /// <returns>The number of days between bringing out and bringing back</returns>
        public int NumOfDaysCalculation()                                               
        {
            if (dateIn != DateTime.Parse("1/1/1000"))
                return (int)(dateIn - dateOut).TotalDays;
            else
                return -1;
        }

        /// <summary>
        /// Output of the general info about the book
        /// </summary>
        public void Output()
        {
            Console.WriteLine("The title of the book: {0}", bookTitle);
            Console.WriteLine("The author of the book: {0}", bookAuthor);
            Console.WriteLine("The number of books out: {0}", booksOut);
            Console.WriteLine("The date of bringing out: {0}", dateOut);
            if (dateIn != DateTime.Parse("1/1/1000"))
            {
                Console.WriteLine("The date of bringing in: {0}", dateIn);
                Console.WriteLine("The number of days the client used the book: {0}", NumOfDaysCalculation());  //using of the method "NumOfDaysCalculation()"
            }
            else
            {
                Console.WriteLine("The date of bringing in: the book is not at the library yet!");
            }
            Console.WriteLine();
            Console.WriteLine("=======================================================================================");
            Console.WriteLine();
        }

        /// <summary>
        /// If the title and the author of two books are similar, the number of books out for the current objects sums with the other
        /// </summary>
        /// <param name="card">The second card you want to process for the sum</param>
        public void Sum (Card card)                                                                             
        {
            if (bookAuthor == card.bookAuthor && bookTitle == card.bookTitle)
            {
                booksOut += card.booksOut;
            }
        }

        /// <summary>
        /// Class destructor
        /// </summary>
        ~Card()
        {
            bookTitle = null;
            bookAuthor = null;
            booksOut = 0;
            dateOut = DateTime.Parse("1/1/1000");
            dateIn = DateTime.Parse("1/1/1000");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Card card1 = new Card();
            Card card2 = new Card("Odyssey of captain Blood", "Rafael Sabatini", 2, DateTime.Parse("5/1/2019"), DateTime.Parse("10/2/2019"));   // Two books with the same
            Card card3 = new Card("Odyssey of captain Blood", "Rafael Sabatini", 5, DateTime.Parse("5/1/2017"), DateTime.Parse("1/2/2017"));    // author and title,
            card2.Sum(card3);                                                                                                                   // that's why we can process them on the Sum() function
            card1.Sum(card2);                                                                                                                   // But here we have the different ones, so will be nothing
            Card card4 = new Card("War and piece", "Lev Tolstoy", 25, DateTime.Parse("10/1/2019"), DateTime.Parse("25/2/2017"));                // The date of in is earlier than out, so it will be "1/1/1000" (nullable)

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// // Output
            card1.Output();
            card2.Output();
            card3.Output();
            card4.Output();
        }
    }
}
