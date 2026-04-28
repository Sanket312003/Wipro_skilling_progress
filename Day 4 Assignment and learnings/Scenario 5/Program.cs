using Day4_Assignment;

using System;
using System.Collections.Generic;

interface ITaskScheduler
{
    void AddTask(string task);
    void AddPriorityTask(int priority, string task);
    void ExecuteTask();
    void UndoTask();
    void ViewTasks();
    void ViewPriorityTasks();
}


class TaskSchedulerService : ITaskScheduler
{
    private Queue<string> taskQueue;
    private Stack<string> undoStack;
    private List<string> allTasks;
    private SortedDictionary<int, string> priorityTasks;
    private HashSet<string> uniqueTasks;

    
    public TaskSchedulerService()
    {
        taskQueue = new Queue<string>();
        undoStack = new Stack<string>();
        allTasks = new List<string>();
        priorityTasks = new SortedDictionary<int, string>();
        uniqueTasks = new HashSet<string>();
    }

    // Adding task
    public void AddTask(string task)
    {
        if (!uniqueTasks.Add(task))
        {
            Console.WriteLine("Task already exists!");
            return;
        }

        taskQueue.Enqueue(task);
        allTasks.Add(task);

        Console.WriteLine("Task added.");
    }

    // Adding pior task
    public void AddPriorityTask(int priority, string task)
    {
        if (!uniqueTasks.Add(task))
        {
            Console.WriteLine("Task already exists!");
            return;
        }

        if (priorityTasks.ContainsKey(priority))
        {
            Console.WriteLine("Priority already used!");
            return;
        }

        priorityTasks.Add(priority, task);
        allTasks.Add(task);

        Console.WriteLine("Priority task added.");
    }

    // Executing task
    public void ExecuteTask()
    {
        if (taskQueue.Count > 0)
        {
            string task = taskQueue.Dequeue();
            undoStack.Push(task);
            Console.WriteLine($"Executed: {task}");
        }
        else if (priorityTasks.Count > 0)
        {
            
            var first = new KeyValuePair<int, string>();
            foreach (var item in priorityTasks)
            {
                first = item;
                break;
            }

            priorityTasks.Remove(first.Key);
            undoStack.Push(first.Value);

            Console.WriteLine($"Executed Priority Task: {first.Value}");
        }
        else
        {
            Console.WriteLine("No tasks to execute.");
        }
    }

    
    public void UndoTask()
    {
        if (undoStack.Count == 0)
        {
            Console.WriteLine("Nothing to undo.");
            return;
        }

        string task = undoStack.Pop();
        taskQueue.Enqueue(task);

        Console.WriteLine($"Undo: {task} added back to queue.");
    }

    //To view all tasks
    public void ViewTasks()
    {
        Console.WriteLine("All Tasks:");
        foreach (var task in allTasks)
        {
            Console.WriteLine(task);
        }
    }

    // Viewing prior tasks
    public void ViewPriorityTasks()
    {
        Console.WriteLine("Priority Tasks:");
        foreach (var item in priorityTasks)
        {
            Console.WriteLine($"Priority {item.Key} → {item.Value}");
        }
    }
}


class Program
{
    static void Main()
    {
        ITaskScheduler scheduler = new TaskSchedulerService();

        while (true)
        {
            Console.WriteLine("\n1. Add Task");
            Console.WriteLine("2. Add Priority Task");
            Console.WriteLine("3. Execute Task");
            Console.WriteLine("4. Undo Task");
            Console.WriteLine("5. View All Tasks");
            Console.WriteLine("6. View Priority Tasks");
            Console.WriteLine("7. Exit");

            Console.Write("Choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter task: ");
                    scheduler.AddTask(Console.ReadLine());
                    break;

                case 2:
                    Console.Write("Enter priority (int): ");
                    int p = int.Parse(Console.ReadLine());
                    Console.Write("Enter task: ");
                    scheduler.AddPriorityTask(p, Console.ReadLine());
                    break;

                case 3:
                    scheduler.ExecuteTask();
                    break;

                case 4:
                    scheduler.UndoTask();
                    break;

                case 5:
                    scheduler.ViewTasks();
                    break;

                case 6:
                    scheduler.ViewPriorityTasks();
                    break;

                case 7:
                    return;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}