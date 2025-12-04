

class Program
{
    static void Main()
    {
        string file = "Mileage.txt";
        List<TrainingEntry> data = ReadFile(file);
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
        for (int i = 0; i < mileage.Count(); i ++)
        {
            for (int j = 0; j < graphHeight; j++) graph[i,j] = " ";
            decimal height = mileage[i] / max * graphHeight - 1;
            Console.WriteLine(data[i].mileage);
            graph[i,(int)height] = "*";
        }
        for (int i = (int)graphHeight-1; i >= 0; i--)
            {
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
        2. Input Mileage");
        switch (number)
        {
            case 1: //View Mileage
                TrainingEntry Totals = new TrainingEntry() {date = DateTime.Today, mileage = 0, crossTraining = 0};
                foreach (TrainingEntry entry in data)
                {
                    Console.WriteLine($"Date: {entry.date.Date}, Miles: {entry.mileage}, Cross Training: {entry.crossTraining} hrs");
                    Totals.mileage += entry.mileage;
                    Totals.crossTraining += entry.crossTraining;
                }
                Console.WriteLine($"{Totals.mileage} miles, {Totals.crossTraining} hrs of cross training");
                Console.WriteLine();
                Graphing(data);
                
                break;
                

            case 2: //Input Mileage
            EnterMileage(data, file);
            break;
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
        while (!success) 
        {    
            Console.Clear();
            Console.Write(message);
            Console.WriteLine();
            string? input = Console.ReadLine();
            success = Int32.TryParse(input, out mileage);
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
                mileage = Int32.Parse(part[1]),
                crossTraining = Int32.Parse(part[2])
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

    class TrainingEntry
    {
        public DateTime date {get; set;}
        public int mileage {get; set;}
        public int crossTraining {get; set;}
    }

}