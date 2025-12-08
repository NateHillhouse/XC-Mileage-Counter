

class Program
{
    static void Main()
    {
        Console.Clear();
        string file = "Mileage.csv";
        List<TrainingEntry> data = ReadFile(file);
        //data.Sort();
        data = data.OrderBy(x => x.date).ToList();
        Options(data, file);
    } 

    static void Graphing(List<TrainingEntry> data)
    {
        int[] mileage = new int[data.Count];
        for(int i = 0; i < data.Count; i++)
        {
            int item = data[i].mileage;
            mileage[i] = item;
        }

        decimal max = mileage.Max();
        decimal graphHeight = 10;
        decimal graphWidth = 20;
        string[,] graph = new string[mileage.Length, (int)graphHeight];

        //Write each row
        for (int i = 0; i < mileage.Count(); i ++)
        {

            
            for (int j = 0; j < graphHeight; j++) graph[i,j] = " ";
            decimal height = mileage[i] / max * graphHeight - 1;

            
            //graph[i,(int)height] = "█";
            for (int x = (int)height; x>=0; x--) graph[i,x] = "█";
            
            /*
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
        for (int i = (int)graphHeight-1; i >= 0; i--)
            {
                if (i == graphHeight-1)
                {
                        if (max.ToString().Length == 2) Console.Write(max);
                    else  Console.Write(max + " ");
                }
                else if (i == (int)(graphHeight-1) /2) {
                if (max.ToString().Length == 2) Console.Write((int)(max)/2);
                    else Console.Write((int)(max)/2 + " ");
                }
                else if (i == 0) Console.Write(0 + " ");
                else Console.Write("  ");
                for (int j = 0; j < graph.Length/10; j++)
                {
                    Console.Write(graph[j,i]);
                }
                Console.WriteLine();
            }


    }
    static void Options(List<TrainingEntry> data, string file)
    {

        Console.WriteLine();
        int number = Getinput(@"What would you like to do?
        1. View Mileage
        2. Input Mileage
        3. Graph Mileage
        4. Exit");
        Console.Clear();
        
        data = data.OrderBy(x => x.date).ToList();
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

            case 3:
            Graphing(data);
            ReturnToMain();
            Options(data, file);
            break;

            case 4:

            break;

            default:
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

            int mileage = Getinput("What was last weeks mileage? ");
            int crossTraining = Getinput("How long did you spend cross training? ");
            DateTime date = DateTime.Today;

            data.Add(new TrainingEntry() {date = date, mileage = mileage, crossTraining = crossTraining});
            WriteFile(data, file);
            return data;
        }  
    }


    static int Getinput(string message)
    {
        bool success = false;
        int mileage = 0;
        
        Console.Write(message);
        Console.WriteLine();
        string? input = Console.ReadLine();
        success = Int32.TryParse(input, out mileage);
        if (mileage < 1) success = false;
        while (!success) 
        {
            Console.Clear();
            Console.WriteLine("Please Pick a Valid Number.");
            Console.WriteLine();
            Console.Write(message);
            Console.WriteLine();
            input = Console.ReadLine();
            success = Int32.TryParse(input, out mileage);
        }
        return mileage;
    }



    static List<TrainingEntry> ReadFile(string file)
    {
        List<TrainingEntry> info = new List<TrainingEntry>();
        
        //info = info.OrderBy(x => x.date).ToList();
        string[] fileinfo = File.ReadAllLines(file);
        for (int line = 0; line < fileinfo.Count(); line++)
        {
            string[] part = fileinfo[line].Split(',');

            info.Add(new TrainingEntry {
                date = DateTime.Parse(part[0]),
                mileage = Int32.Parse(part[1]),
                crossTraining = Int32.Parse(part[2])
            });
            
        }
        return info;
    }
    static void WriteFile(List<TrainingEntry> trainingEntries, string path)
    {
        
        //trainingEntries = trainingEntries.OrderBy(x => x.date).ToList();
        List<string> info = new List<string>();
        foreach (TrainingEntry line in trainingEntries)
        {
            info.Add(line.date.ToString() + ',' + line.mileage.ToString() + ',' + line.crossTraining.ToString());
        }
        File.WriteAllLines(path, info);
    }

    class TrainingEntry
    {
        public DateTime date {get; set;}
        public int mileage {get; set;}
        public int crossTraining {get; set;}
    }

}