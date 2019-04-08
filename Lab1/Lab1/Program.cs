using System;

namespace Lab1
{
    class Card
    {
        private string bookTitle;      // the title of the book
        private string bookAuthor;     // the author of the book
        private int booksOut;          // the general num of books out
        private DateTime dateOut;      // the date of giving the book to the client
        private DateTime dateIn;       // the date of bringing back the book

        /// <summary>
        /// Constructor by default. We use it in case we have no parametrs.
        /// Places in the tags of title and author value "Deafault", value of books out of the library is 0,
        /// the initial date for the book out is "initial point" ('01.01.1970') and the end date is the nullable year for this application
        /// (because DateTime can't has the nullable value)
        /// </summary>
        public Card()
        {
            bookTitle = "Deafualt";                 // Making title and
            bookAuthor = "Default";                 // author defaults
            booksOut = 0;                           // By default the num of books out is 0
            dateOut = new DateTime(1970, 1, 1);     // the common default time
            dateIn = new DateTime(1000, 1, 1);      // nullable time for the current program
        }

        /// <summary>
        /// Constructor for the input data (if we have some parameters in bracets while the object initialized)
        /// </summary>
        /// <param name="title">Title of the book</param>
        /// <param name="author">Author of the book</param>
        /// <param name="outs">The number of books out</param>
        /// <param name="dOut">The date the client brought out the book</param>
        /// <param name="dIn">The date (if it exists) the client brought book back</param>
        public Card(string title, string author, int outs, DateTime dOut, DateTime dIn)
        {
            bookTitle = title;                                                          // Putting the title of the book
            bookAuthor = author;                                                        // Putting the author of the book
            booksOut = outs;                                                            // Putting the day the book was brought out of the library
            dateOut = dOut;                                                             // -||-                     was brought in the library

            if (dIn > dOut)                                                             // If the day of bringig back was earlier than out, the back is nullabe
                dateIn = dIn;                                                           // Else the date is like a similar parameter
            else
                dateIn = DateTime.Parse("1/1/1000");
        }

        /// <summary>
        /// Calculates the number of days between out and in
        /// </summary>
        /// <returns>The number of days between bringing out and bringing back</returns>
        public int NumOfDaysCalculation()                                               
        {
            if (dateIn != DateTime.Parse("1/1/1000"))                                   // Checking the nullable time. If everything is OK
                return (int)(dateIn - dateOut).TotalDays;                               // return the difference between the initial and the end date
            else
                return -1;                                                              // else it returns the mistake (-1 code)
        }

        /// <summary>
        /// Output of the general info about the book
        /// </summary>
        public void Output()
        {
            Console.WriteLine("The title of the book: {0}", bookTitle);                 // Output the title
            Console.WriteLine("The author of the book: {0}", bookAuthor);               // the author
            Console.WriteLine("The number of books out: {0}", booksOut);                // the num of books out at this moment
            Console.WriteLine("The date of bringing out: {0}", dateOut);                // the date of bringing out
            if (dateIn != DateTime.Parse("1/1/1000"))                                   // Checking the nullable value of the date of bringing in
            {
                Console.WriteLine("The date of bringing in: {0}", dateIn);
                Console.WriteLine("The number of days the client used the book: {0}", NumOfDaysCalculation());  //using of the method "NumOfDaysCalculation()"
            }                                                                                                   // If the book hasn't been brought yet
            else
            {
                Console.WriteLine("The date of bringing in: the book is not at the library yet!");              // output contains this information
            }
            Console.WriteLine();
            Console.WriteLine("======================================================================================="); // Splitting the output of different books for
            Console.WriteLine();                                                                                          // the better view
        }

        /// <summary>
        /// If the title and the author of two books are similar, the number of books out for the current objects sums with the other
        /// </summary>
        /// <param name="card">The second card you want to process for the sum</param>
        public void Sum (Card card)                                                                             
        {
            if (bookAuthor == card.bookAuthor && bookTitle == card.bookTitle)                                   // If the books are similar
            {                                                                                                   // (by their author and title)
                booksOut += card.booksOut;                                                                      // we add the value of books out of the second book
            }                                                                                                   // to the first book
        }

        /// <summary>
        /// Class destructor
        /// It puts the nullable values (global or only for this program) or 0 values (for the num of books were brought out)
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
            Card card1 = new Card();                                                                                                            // Using the constructor by default
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
