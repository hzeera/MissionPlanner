using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using log4net;
using log4net.Config;

namespace ArdupilotMega
{
    class StepperController
    {
        private SerialPort port;
        private Thread readThread;
        private Boolean run;
        private Queue<Tuple<char, int>> commands;
        private Tuple<char, int> currentCommand;
        private static readonly ILog log = LogManager.GetLogger("StepperController");

        public StepperController(String portName, int baudRate)
        {
            run = true;
            commands = new Queue<Tuple<char, int>>();
            port = new SerialPort(portName, baudRate);
        }
        
        public void setPortName(String portName)
        {
            if (port.IsOpen)
            {
                log.Error("Cannot change port name when Serial Port is open.");
                return;
            }
            port.PortName = portName;
        }

        public void setBaudRate(int baudRate)
        {
            port.BaudRate = baudRate;
        }

        public void Open()
        {
            if (!port.IsOpen)
            {
                try
                {
                    port.Open();
                }
                catch (Exception e)
                {
                    log.Error(e.Message);
                }
            }
            readThread = new Thread(this.Read);
            readThread.Start();
        }

        private void Read()
        {
            while (run)
            {
                try
                {
                    char reply = (char)port.ReadChar();
                    switch(reply)
                    {
                        case 'N':
                            log.Error("Invalid Mode");
                            break;
                        case 'O':
                            log.Error("Out of Range");
                            break;
                        case 'M':
                            if (commands.Count > 0)
                            {
                                currentCommand = commands.Dequeue();
                                port.Write(currentCommand.Item1.ToString());
                            }
                            break;
                        default:
                            if (currentCommand.Item1 != reply)
                            {
                                log.Error("Command mismatch: Command='" + currentCommand.Item1 + "', Reply='" + reply + "'");
                                break;
                            }
                            port.Write(currentCommand.Item2.ToString());
                            currentCommand = null;
                            break;
                    }

                }
                catch (Exception e)
                {
                    log.Error(e.Message);
                }
            }
        }

        public void setAngle(int angle)
        {
            if (angle > 360)
            {
                log.Error("Angle out of range");
                return;
            }
            int newAngle = 200 * angle / 360;
            handleCommand('A', newAngle);
        }

        public void setStep(int steps)
        {
            if (steps > 200 || steps < -200)
            {
                log.Error("Steps out of range");
                return;
            }
            handleCommand('S', steps);
        }

        public void setBrake(int power)
        {
            if (power < 0 || power > 255)
            {
                log.Error("Power out of range");
                return;
            }
            handleCommand('B', power);
        }

        public void setSpeed(int speed)
        {
            if (speed < 0 || speed > 240)
            {
                log.Error("Speed out of range");
                return;
            }
            handleCommand('P', speed);
        }

        private void handleCommand(char mode, int value)
        {
            if (commands.Count == 0 && currentCommand == null)
            {
                currentCommand = new Tuple<char, int>(mode, value);
                port.Write(mode.ToString());
            }
            else
            {
                commands.Enqueue(new Tuple<char, int>(mode, value));
            }
        }

    }
}
