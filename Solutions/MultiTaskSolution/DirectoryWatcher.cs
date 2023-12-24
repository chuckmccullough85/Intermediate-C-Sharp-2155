
namespace MultiTask;

public class DirectoryWatcher
{
    private string _directory;
    private Thread _watcherThread;
    public DirectoryWatcher(string directory)
    {
        _directory = directory;
        //TODO create a thread on Run
        //TODO make the thread a daemon
        //TODO start the thread
    }
    public void Run()
    {
        while (true)
        {
            var time = Directory.GetLastWriteTime(_directory);
            var files = Directory.GetFiles(_directory);
            foreach (var f in files)
            {
                Console.WriteLine(f);
            }
            while (time == Directory.GetLastWriteTime(_directory))
                Thread.Sleep(1000);
            Console.WriteLine("\n---------------------\n");
        }
    }