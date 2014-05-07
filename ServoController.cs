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
    /**
     * Singleton class to control the camera servos.
     * Protocol:
     * Inbound Messages:
     * 'N' = Invalid
     * 'O' = Out of Range
     * 'M' = Ready
     * 
     * Outbound Messages:
     * 'A' = Absolute Angle
     * 'S' = Relative Angle
     * 
     * Format: 
     * Send 'A/S' -> Receive 'A/S' -> Send '{PanAngle}B{TiltAngle}'
     **/
    class ServoController
    {
        private SerialPort port;
        private Thread readThread;
        private Boolean run;
        private Queue<Tuple<char, int, int>> commands;
        private Tuple<char, int, int> currentCommand;
        private static readonly ILog log = LogManager.GetLogger("ServoController");
        private static ServoController controller;

        public static ServoController getInstance()
        {
            if (controller == null)
                controller = new ServoController();
            return controller;
        }

        private ServoController()
        {
            run = true;
            commands = new Queue<Tuple<char, int, int>>();
            port = new SerialPort();
        }
        
        public void setPortName(String portName)
        {
            if (!port.IsOpen)
            {
                port.PortName = portName;
            }
        }

        public void setBaudRate(int baudRate)
        {
            if (!port.IsOpen)
            {
                port.BaudRate = baudRate;
            }
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

                readThread = new Thread(this.Read);
                readThread.Start();
            }
        }

        public void Close()
        {
            if (port.IsOpen)
            {
                run = false;
                port.Close();
            }
        }

        private void Read()
        {
            while (run)
            {
                try
                {
                    char reply = (char)port.ReadChar();
                    log.Debug(reply);
                    switch(reply)
                    {
                        case 'N':
                            log.Error("Invalid Mode");
                            break;
                        case 'O':
                            log.Error("Out of Range");
                            break;
                        case 'M':
                            break;
                        default:
                            if (currentCommand.Item1 != reply)
                            {
                                log.Error("Command mismatch: Command='" + currentCommand.Item1 + "', Reply='" + reply + "'");
                                break;
                            }
                            port.Write(currentCommand.Item2.ToString() + "B" + currentCommand.Item3.ToString());
                            currentCommand = null;
                            log.Debug("Sent: " + currentCommand.Item2.ToString() + "B" + currentCommand.Item3.ToString());
                            break;
                    }
                    if (commands.Count > 0 && currentCommand == null)
                    {
                        currentCommand = commands.Dequeue();
                        port.Write(currentCommand.Item1.ToString());
                        log.Debug("Sent: " + currentCommand.Item1.ToString());
                    }

                }
                catch (Exception e)
                {
                    log.Error(e.Message);
                }
            }

            if (port.IsOpen)
                port.Close();
        }

        public void setAngle(int panAngle, int tiltAngle)
        {
            if (panAngle > 360 || tiltAngle > 360 || panAngle < 0 || tiltAngle < 0)
            {
                log.Error("Angle out of range");
                return;
            }
            handleCommand('A', panAngle, tiltAngle);
        }

        public void setStep(int panSteps, int tiltSteps)
        {
            if (panSteps > 200 || panSteps < -200 || tiltSteps > 200 || tiltSteps < -200)
            {
                log.Error("Steps out of range");
                return;
            }
            handleCommand('S', panSteps, tiltSteps);
        }

        private void handleCommand(char mode, int value1, int value2)
        {
            if (commands.Count == 0 && currentCommand == null)
            {
                currentCommand = new Tuple<char, int, int>(mode, value1, value2);
                port.Write(mode.ToString());
            }
            else if(commands.Count < 2)
            {
                commands.Enqueue(new Tuple<char, int, int>(mode, value1, value2));
            }
        }

    }
}
