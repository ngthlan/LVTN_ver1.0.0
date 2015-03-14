﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LAB_MANAGER.VIEW
{
    public partial class trydemo : Form
    {
        public trydemo()
        {
            InitializeComponent();
        }

        #region Button
        private void but_try1_Click(object sender, EventArgs e)
        {
            /*
Thread Start/Stop/Join Sample
Alpha.Beta is running in its own thread.
Alpha.Beta is running in its own thread.
Alpha.Beta is running in its own thread.
...
...
Alpha.Beta has finished
Try to restart the Alpha.Beta thread
ThreadStateException trying to restart Alpha.Beta. Expected since aborted threads cannot be restarted.
             */
            trydemo1();
        }

        private void button_try2_Click(object sender, EventArgs e)
        {
            /*
Produce: 1
Consume: 1
Produce: 2
Consume: 2
Produce: 3
Consume: 3
...
...
Produce: 20
Consume: 20
             */
            int result = 0;   // Result initialized to say there is no error
            Cell cell = new Cell();

            CellProd prod = new CellProd(cell, 20);  // Use cell for storage, 
            // produce 20 items
            CellCons cons = new CellCons(cell, 20);  // Use cell for storage, 
            // consume 20 items

            Thread producer = new Thread(new ThreadStart(prod.ThreadRun));
            Thread consumer = new Thread(new ThreadStart(cons.ThreadRun));
            // Threads producer and consumer have been created, 
            // but not started at this point.

            try
            {
                producer.Start();
                consumer.Start();

                producer.Join();   // Join both threads with no timeout
                // Run both until done.
                consumer.Join();
                // threads producer and consumer have finished at this point.
            }
            catch (ThreadStateException ex)
            {
                Console.WriteLine(ex);  // Display text of exception
                result = 1;            // Result says there was an error
            }
            catch (ThreadInterruptedException ex)
            {
                Console.WriteLine(ex);  // This exception means that the thread
                // was interrupted during a Wait
                result = 1;            // Result says there was an error
            }
            // Even though Main returns void, this provides a return code to 
            // the parent process.
            Environment.ExitCode = result;
        }

        private void button_try3_Click(object sender, EventArgs e)
        {
            /*
Thread Pool Sample:
Queuing 10 items to Thread Pool
Queue to Thread Pool 0
Queue to Thread Pool 1
...
...
Queue to Thread Pool 9
Waiting for Thread Pool to drain
 98 0 :
HashCount.Count==0, Thread.CurrentThread.GetHashCode()==98
 100 1 :
HashCount.Count==1, Thread.CurrentThread.GetHashCode()==100
 98 2 :
...
...
Setting eventX
Thread Pool has been drained (Event fired)

Load across threads
101 2
100 3
98 4
102 1
             */
            trydemo3();
        }

        private void button_try4_Click(object sender, EventArgs e)
        {
            /*
Mutex Sample ...
 - Main Owns gM1 and gM2
t1Start started,  Mutex.WaitAll(Mutex[])
t2Start started,  gM1.WaitOne( )
t3Start started,  Mutex.WaitAny(Mutex[])
t4Start started,  gM2.WaitOne( )
 - Main releases gM1
t2Start finished, gM1.WaitOne( ) satisfied
t3Start finished, Mutex.WaitAny(Mutex[])
 - Main releases gM2
t1Start finished, Mutex.WaitAll(Mutex[]) satisfied
t4Start finished, gM2.WaitOne( )
... Mutex Sample             
             */
            MutexSample tm = new MutexSample();
            tm.run();
        }

        public int trydemo1()
        {
            Console.WriteLine("Thread Start/Stop/Join Sample");

            Alpha oAlpha = new Alpha();

            // Create the thread object, passing in the Alpha.Beta method
            // via a ThreadStart delegate. This does not start the thread.
            Thread oThread = new Thread(new ThreadStart(oAlpha.Beta));

            // Start the thread
            oThread.Start();

            // Spin for a while waiting for the started thread to become
            // alive:
            while (!oThread.IsAlive) ;

            // Put the Main thread to sleep for 1 millisecond to allow oThread
            // to do some work:
            Thread.Sleep(1);

            // Request that oThread be stopped
            oThread.Abort();

            // Wait until oThread finishes. Join also has overloads
            // that take a millisecond interval or a TimeSpan object.
            oThread.Join();

            Console.WriteLine();
            Console.WriteLine("Alpha.Beta has finished");

            try
            {
                Console.WriteLine("Try to restart the Alpha.Beta thread");
                oThread.Start();
            }
            catch (ThreadStateException)
            {
                Console.Write("ThreadStateException trying to restart Alpha.Beta. ");
                Console.WriteLine("Expected since aborted threads cannot be restarted.");
            }
            return 0;
        }

        public int trydemo3()
        {
            Console.WriteLine("Thread Pool Sample:");
            bool W2K = false;
            int MaxCount = 10;  // Allow a total of 10 threads in the pool
            // Mark the event as unsignaled.
            ManualResetEvent eventX = new ManualResetEvent(false);
            Console.WriteLine("Queuing {0} items to Thread Pool", MaxCount);
            Alpha3 oAlpha = new Alpha3(MaxCount);  // Create the work items.
            // Make sure the work items have a reference to the signaling event.
            oAlpha.eventX = eventX;
            Console.WriteLine("Queue to Thread Pool 0");
            try
            {
                // Queue the work items, which has the added effect of checking
                // which OS is running.
                ThreadPool.QueueUserWorkItem(new WaitCallback(oAlpha.Beta),
                   new SomeState(0));
                W2K = true;
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("These API's may fail when called on a non-Windows 2000 system.");
                W2K = false;
            }
            if (W2K)  // If running on an OS which supports the ThreadPool methods.
            {
                for (int iItem = 1; iItem < MaxCount; iItem++)
                {
                    // Queue the work items:
                    Console.WriteLine("Queue to Thread Pool {0}", iItem);
                    ThreadPool.QueueUserWorkItem(new WaitCallback(oAlpha.Beta), new SomeState(iItem));
                }
                Console.WriteLine("Waiting for Thread Pool to drain");
                // The call to exventX.WaitOne sets the event to wait until
                // eventX.Set() occurs.
                // (See oAlpha.Beta).
                // Wait until event is fired, meaning eventX.Set() was called:
                eventX.WaitOne(Timeout.Infinite, true);
                // The WaitOne won't return until the event has been signaled.
                Console.WriteLine("Thread Pool has been drained (Event fired)");
                Console.WriteLine();
                Console.WriteLine("Load across threads");
                foreach (object o in oAlpha.HashCount.Keys)
                    Console.WriteLine("{0} {1}", o, oAlpha.HashCount[o]);
            }
            return 0;
        }

        
        #endregion Button
    }


    #region Locals
    
    //try1
    public class Alpha
    {

        // This method that will be called when the thread is started
        public void Beta()
        {
            while (true)
            {
                Console.WriteLine("Alpha.Beta is running in its own thread.");
            }
        }
    };
    //

    //try2
    public class CellProd
    {
        Cell cell;         // Field to hold cell object to be used
        int quantity = 1;  // Field for how many items to produce in cell

        public CellProd(Cell box, int request)
        {
            cell = box;          // Pass in what cell object to be used
            quantity = request;  // Pass in how many items to produce in cell
        }
        public void ThreadRun()
        {
            for (int looper = 1; looper <= quantity; looper++)
                cell.WriteToCell(looper);  // "producing"
        }
    }

    public class CellCons
    {
        Cell cell;         // Field to hold cell object to be used
        int quantity = 1;  // Field for how many items to consume from cell

        public CellCons(Cell box, int request)
        {
            cell = box;          // Pass in what cell object to be used
            quantity = request;  // Pass in how many items to consume from cell
        }
        public void ThreadRun()
        {
            int valReturned;
            for (int looper = 1; looper <= quantity; looper++)
                // Consume the result by placing it in valReturned.
                valReturned = cell.ReadFromCell();
        }
    }

    public class Cell
    {
        int cellContents;         // Cell contents
        bool readerFlag = false;  // State flag
        public int ReadFromCell()
        {
            lock (this)   // Enter synchronization block
            {
                if (!readerFlag)
                {            // Wait until Cell.WriteToCell is done producing
                    try
                    {
                        // Waits for the Monitor.Pulse in WriteToCell
                        Monitor.Wait(this);
                    }
                    catch (SynchronizationLockException e)
                    {
                        Console.WriteLine(e);
                    }
                    catch (ThreadInterruptedException e)
                    {
                        Console.WriteLine(e);
                    }
                }
                Console.WriteLine("Consume: {0}", cellContents);
                readerFlag = false;    // Reset the state flag to say consuming
                // is done.
                Monitor.Pulse(this);   // Pulse tells Cell.WriteToCell that
                // Cell.ReadFromCell is done.
            }   // Exit synchronization block
            return cellContents;
        }

        public void WriteToCell(int n)
        {
            lock (this)  // Enter synchronization block
            {
                if (readerFlag)
                {      // Wait until Cell.ReadFromCell is done consuming.
                    try
                    {
                        Monitor.Wait(this);   // Wait for the Monitor.Pulse in
                        // ReadFromCell
                    }
                    catch (SynchronizationLockException e)
                    {
                        Console.WriteLine(e);
                    }
                    catch (ThreadInterruptedException e)
                    {
                        Console.WriteLine(e);
                    }
                }
                cellContents = n;
                Console.WriteLine("Produce: {0}", cellContents);
                readerFlag = true;    // Reset the state flag to say producing
                // is done
                Monitor.Pulse(this);  // Pulse tells Cell.ReadFromCell that 
                // Cell.WriteToCell is done.
            }   // Exit synchronization block
        }
    }
    //

    //try3
    public class SomeState
    {
        public int Cookie;
        public SomeState(int iCookie)
        {
            Cookie = iCookie;
        }
    }

    public class Alpha3
    {
        public Hashtable HashCount;
        public ManualResetEvent eventX;
        public static int iCount = 0;
        public static int iMaxCount = 0;
        public Alpha3(int MaxCount)
        {
            HashCount = new Hashtable(MaxCount);
            iMaxCount = MaxCount;
        }

        // Beta is the method that will be called when the work item is
        // serviced on the thread pool.
        // That means this method will be called when the thread pool has
        // an available thread for the work item.
        public void Beta(Object state)
        {
            // Write out the hashcode and cookie for the current thread
            Console.WriteLine(" {0} {1} :", Thread.CurrentThread.GetHashCode(),
               ((SomeState)state).Cookie);
            // The lock keyword allows thread-safe modification
            // of variables accessible across multiple threads.
            Console.WriteLine(
               "HashCount.Count=={0}, Thread.CurrentThread.GetHashCode()=={1}",
               HashCount.Count,
               Thread.CurrentThread.GetHashCode());
            lock (HashCount)
            {
                if (!HashCount.ContainsKey(Thread.CurrentThread.GetHashCode()))
                    HashCount.Add(Thread.CurrentThread.GetHashCode(), 0);
                HashCount[Thread.CurrentThread.GetHashCode()] =
                   ((int)HashCount[Thread.CurrentThread.GetHashCode()]) + 1;
            }

            // Do some busy work.
            // Note: Depending on the speed of your machine, if you 
            // increase this number, the dispersement of the thread
            // loads should be wider.
            int iX = 2000;
            Thread.Sleep(iX);
            // The Interlocked.Increment method allows thread-safe modification
            // of variables accessible across multiple threads.
            Interlocked.Increment(ref iCount);
            if (iCount == iMaxCount)
            {
                Console.WriteLine();
                Console.WriteLine("Setting eventX ");
                eventX.Set();
            }
        }
    }
    //

    //trydemo4()
    public class MutexSample
    {
        public static Mutex gM1;
        public static Mutex gM2;
        const int ITERS = 100;
        public static AutoResetEvent Event1 = new AutoResetEvent(false);
        public static AutoResetEvent Event2 = new AutoResetEvent(false);
        public static AutoResetEvent Event3 = new AutoResetEvent(false);
        public static AutoResetEvent Event4 = new AutoResetEvent(false);

        //AutoResetEvent[] evs = new AutoResetEvent[4];
        public void run()
        {
            Console.WriteLine("Mutex Sample ...");
            // Create Mutex initialOwned, with name of "MyMutex".
            gM1 = new Mutex(true, "MyMutex");
            // Create Mutex initialOwned, with no name.
            gM2 = new Mutex(true);
            Console.WriteLine(" - Main Owns gM1 and gM2");

            AutoResetEvent[] evs = new AutoResetEvent[4];
            evs [0] = Event1;    // Event for t1
            evs[1] = Event2;    // Event for t2
            evs[2] = Event3;    // Event for t3
            evs[3] = Event4;    // Event for t4

            MutexSample tm = new MutexSample();
            Thread t1 = new Thread(new ThreadStart(tm.t1Start));
            Thread t2 = new Thread(new ThreadStart(tm.t2Start));
            Thread t3 = new Thread(new ThreadStart(tm.t3Start));
            Thread t4 = new Thread(new ThreadStart(tm.t4Start));
            t1.Start();   // Does Mutex.WaitAll(Mutex[] of gM1 and gM2)
            t2.Start();   // Does Mutex.WaitOne(Mutex gM1)
            t3.Start();   // Does Mutex.WaitAny(Mutex[] of gM1 and gM2)
            t4.Start();   // Does Mutex.WaitOne(Mutex gM2)

            Thread.Sleep(2000);
            Console.WriteLine(" - Main releases gM1");
            gM1.ReleaseMutex();  // t2 and t3 will end and signal

            Thread.Sleep(1000);
            Console.WriteLine(" - Main releases gM2");
            gM2.ReleaseMutex();  // t1 and t4 will end and signal

            // Waiting until all four threads signal that they are done.
            WaitHandle.WaitAll(evs);
            Console.WriteLine("... Mutex Sample");
        }

        public void t1Start( )
        {
            Console.WriteLine("t1Start started,  Mutex.WaitAll(Mutex[])");
            Mutex[] gMs = new Mutex[2];
            gMs[0] = gM1;  // Create and load an array of Mutex for WaitAll call
            gMs[1] = gM2;
            Mutex.WaitAll(gMs);  // Waits until both gM1 and gM2 are released
            Thread.Sleep(2000);
            Console.WriteLine("t1Start finished, Mutex.WaitAll(Mutex[]) satisfied");
            Event1.Set( );      // AutoResetEvent.Set() flagging method is done
        }

        public void t2Start( )
        {
            Console.WriteLine("t2Start started,  gM1.WaitOne( )");
            gM1.WaitOne( );    // Waits until Mutex gM1 is released
            Console.WriteLine("t2Start finished, gM1.WaitOne( ) satisfied");
            Event2.Set( );     // AutoResetEvent.Set() flagging method is done
        }

        public void t3Start( )
        {
            Console.WriteLine("t3Start started,  Mutex.WaitAny(Mutex[])");
            Mutex[] gMs = new Mutex[2];
            gMs[0] = gM1;  // Create and load an array of Mutex for WaitAny call
            gMs[1] = gM2;
            Mutex.WaitAny(gMs);  // Waits until either Mutex is released
            Console.WriteLine("t3Start finished, Mutex.WaitAny(Mutex[])");
            Event3.Set( );       // AutoResetEvent.Set() flagging method is done
        }

        public void t4Start( )
        {
            Console.WriteLine("t4Start started,  gM2.WaitOne( )");
            gM2.WaitOne( );   // Waits until Mutex gM2 is released
            Console.WriteLine("t4Start finished, gM2.WaitOne( )");
            Event4.Set( );    // AutoResetEvent.Set() flagging method is done
        }
    }
    //
    #endregion Locals
}
