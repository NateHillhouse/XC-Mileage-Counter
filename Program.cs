// Mileage Tracker
// Nathan Hillhouse
// A Console application to track running mileage
// CS1400
using System.Diagnostics;

class Program
{
    static void Main()
    {
        Console.Clear();
        string file = "Mileage.csv";
        List<TrainingEntry> data = ReadFile(file);
        //data.Sort();
        data = data.OrderBy(x => x.date).ToList();    
        Debug.Assert(data[0].date < data[1].date);
        Debug.Assert(data[1].date <  data[2].date);
        Options(data, file);
    } 

    static void Graphing(List<TrainingEntry> data)
    {
        if (data.Count > 0)
        {
            //Transform data into an array for display
            double[] mileage = new double[data.Count];
            for(int i = 0; i < data.Count; i++)
            {
                double item = data[i].mileage;
                mileage[i] = item;
            }

            double max = mileage.Max();

            //Used to determine how many spaces tall the graph takes
            double graphHeight = 10;
            string[,] graph = new string[mileage.Length, (int)graphHeight];

            //Write each row
            for (int i = 0; i < mileage.Count(); i ++)
            {

                
                for (int j = 0; j < graphHeight; j++) graph[i,j] = " ";
                double height = mileage[i] / max * graphHeight - 1;

                //Set each character needed as "█"
                for (int x = (int)height; x>=0; x--) graph[i,x] = "█";
                
                /*
                //Attempt at a line graph; changed to bar graph
                //I have left this in case I would like to return to it at a later date

                int nextItem = data[i].mileage;
                int previousItem = data[i].mileage;
                if (!(i+1 >= data.Count)) nextItem = data[i+1].mileage;
                if (!(i-1 <= 0)) previousItem = data[i-1].mileage;

                if (nextItem < data[i].mileage && previousItem < data[i].mileage) graph[i,(int)height] = "█";
                else if (nextItem > data[i].mileage && previousItem > data[i].mileage) graph[i,(int)height] = "v";
                else if (nextItem > data[i].mileage) graph[i,(int)height] = "/";
                else if (nextItem == data[i].mileage) graph[i,(int)height] = "_";
                else if (nextItem < data[i].mileage) graph[i,(int)height] = "\\";
                else if (nextItem < data[i].mileage && data[i].mileage < i) graph[i, (int)height] = "|";
                */
                
            }
            string[] numberLengths = [max.ToString(), ((graphHeight-1) /2).ToString()];
            int longestNumber = 1;
            foreach (string item in numberLengths) if (item.Length > longestNumber) longestNumber = item.Length;
            //Write the graph to the console
            for (int i = (int)graphHeight-1; i >= 0; i--)
                {
                    //Top number
                    if (i == graphHeight-1)
                    {
                        Console.Write(max);
                        WriteSpace(longestNumber - max.ToString().Length);
                    }
                    //Middle number
                    else if (i == (int)(graphHeight-1) /2) 
                    {
                        Console.Write((int)max/2);
                        WriteSpace(longestNumber - ((int)max/2).ToString().Length);
                    }
                    else if (i == 0) 
                    {
                        Console.Write(1);
                        WriteSpace(longestNumber-1);
                    }
                    else WriteSpace(longestNumber);
                    for (int j = 0; j < graph.Length/10; j++)
                    {
                        Console.Write(graph[j,i]);
                    }
                    Console.WriteLine();
                }

            void WriteSpace(int number)
                    {
                        for (int j = 0; j < number; j++) Console.Write(" ");
                    }

                //Get average mileage
                int sum = 0; int count = 0;
                foreach (int item in mileage) {
                    sum += item;
                    count ++;
                }
                Console.WriteLine($"Your average mileage is: {(double)sum / count}");
                NextWeeksMileage(data);
        }
        else Console.WriteLine("You do not have enough data to display a graph");
    }
            static void NextWeeksMileage(List<TrainingEntry> data)
        {
            List<double> averages = new List<double>();
            for (int i = 0; i < data.Count; i ++) 
            {
                if (i < data.Count-1) averages.Add((data[i].mileage + data[i].mileage)/2);
            }
            double avgIncrease = averages.Average();
            Console.WriteLine($"Next weeks mileage {data[data.Count-1].mileage * 1.05}");
        }
    static void Options(List<TrainingEntry> data, string file)
    {
        //Display the menu
        Console.WriteLine();
        double number = Getinput(@"What would you like to do?
        1. View Mileage
        2. Input Mileage
        3. Graph Mileage
        4. Exit");
        Console.Clear();
        
        Debug.Assert(number > 0 && number < 5);

        //Sort the data incase new data is added
        data = data.OrderBy(x => x.date).ToList();

        //Choose function that the user has chosen
        switch (number)
        {
            case 1: //View Mileage
                TrainingEntry Totals = new TrainingEntry() {date = DateTime.Today, mileage = 0, crossTraining = 0};
                string title = "Miles | Cross Training | Date";
                Console.WriteLine($"{title, 35}");
                foreach (TrainingEntry entry in data)
                {
                    Console.WriteLine($"{entry.mileage,3+6} {"|" ,3} {entry.crossTraining,8} {"|" ,7} {entry.date.ToString("MM/dd/yyyy")} ");
                    Totals.mileage += entry.mileage;
                    Totals.crossTraining += entry.crossTraining;
                }
                Console.Write($"Totals");
                for (int i = 6; i > 0; i--) Console.Write("-");
                Console.Write("|");
                for (int i = 16; i > 0; i--) Console.Write("-");
                Console.WriteLine("|");
                Console.WriteLine($"{Totals.mileage,3+6} {"|" ,3} {Totals.crossTraining,8} {"|" ,7}");
                Console.WriteLine();
                ReturnToMain();
                Options(data, file);
                break;
                

            case 2: //Input Mileage
                EnterMileage(data, file);
                ReturnToMain();
                Options(data, file);
                break;

            case 3: //Graph Mileage
                Graphing(data);
                ReturnToMain();
                Options(data, file);
                break;

            case 4: //Exit
                break;

            default: //Retry input
                Console.Clear();
                Console.WriteLine("Please Pick a Valid Number. ");
                Options(data, file);
                break;
        }

        static void ReturnToMain()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue ");
            Console.ReadKey(true);
            Console.Clear();
            
        }



        List<TrainingEntry> EnterMileage(List<TrainingEntry> data, string file)
        {

            double mileage = Getinput("What was last weeks mileage? ");
            double crossTraining = Getinput("How long did you spend cross training? ");
            DateTime date = DateTime.Today;

            data.Add(new TrainingEntry() {date = date, mileage = mileage, crossTraining = crossTraining});
            WriteFile(data, file);
            return data;
        }  
    }


    static double Getinput(string message)
    {
        bool success;
        double mileage;
        Console.Write(message);
        Console.WriteLine();
        string? input = Console.ReadLine();
        success = double.TryParse(input, out mileage);
        if (mileage < 1) success = false;
        while (!success) 
        {
            Console.Clear();
            Console.WriteLine("Please Pick a Valid Number.");
            Console.WriteLine();
            Console.Write(message);
            Console.WriteLine();
            input = Console.ReadLine();
            success = double.TryParse(input, out mileage);
        }
        return mileage;
    }



    static List<TrainingEntry> ReadFile(string file)
    {
        List<TrainingEntry> info = new List<TrainingEntry>();
        
        string[] fileinfo = File.ReadAllLines(file);
        for (int line = 0; line < fileinfo.Count(); line++)
        {
            string[] part = fileinfo[line].Split(',');

            info.Add(new TrainingEntry {
                date = DateTime.Parse(part[0]),
                mileage = double.Parse(part[1]),
                crossTraining = double.Parse(part[2])
            });
            
        }
        return info;
    }
    static void WriteFile(List<TrainingEntry> trainingEntries, string path)
    {
        List<string> info = new List<string>();
        foreach (TrainingEntry line in trainingEntries)
        {
            info.Add(line.date.ToString() + ',' + line.mileage.ToString() + ',' + line.crossTraining.ToString());
        }
        File.WriteAllLines(path, info);
    }

    class TrainingEntry //Holds main data
    {
        public DateTime date {get; set;}
        public double mileage {get; set;}
        public double crossTraining {get; set;}
    }

}