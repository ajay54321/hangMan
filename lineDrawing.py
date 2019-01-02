from tkinter import *
from threading import *

class RepeatedTimer(object):
    def __init__(self, interval, function, *args, **kwargs):
        self._timer     = None
        self.interval   = interval
        self.function   = function
        self.args       = args
        self.kwargs     = kwargs
        self.is_running = False
        self.start()

    def _run(self):
        self.is_running = False
        self.start()
        self.function(*self.args, **self.kwargs)

    def start(self):
        if not self.is_running:
            self._timer = Timer(self.interval, self._run)
            self._timer.start()
            self.is_running = True

    def stop(self):
        self._timer.cancel()
        self.is_running = False

def decrement():
    global counter
    counter = counter + 10
    drawTheLine(counter)

def drawTheLine(x):
 can.create_line(0, 0, 200, x-3 , fill ="blue") 
 can.create_line(0, 0, 200, x, fill="red")
 print(x)

counter = 10

obj = Tk()
can = Canvas(obj,bg = "blue", height = 250, width = 300)
can.pack()
rt = RepeatedTimer(1, decrement) 
obj.mainloop()  
