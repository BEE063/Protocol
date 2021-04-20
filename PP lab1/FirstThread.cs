using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using ThreadsEdu;

namespace PP_lab1
{
    public class FirstThread
    {
        private Semaphore _sendSemaphore;
        private Semaphore _receiveSemaphore;
        private BitArray _receivedMessage;
        private BitArray _sendMessage;
        private PostToSecondWT _post;

        public FirstThread(ref Semaphore sendSemaphore, ref Semaphore receiveSemaphore)
        {
            _sendSemaphore = sendSemaphore;
            _receiveSemaphore = receiveSemaphore;
        }
        public void FirstThreadMain(object obj)
        {
            _post = (PostToSecondWT)obj;
            ConsoleHelper.WriteToConsole("1 поток", "Начинаю работу.Готовлю данные для передачи.");
            _sendMessage = new BitArray(64);
            Frame.GenerateData(_sendMessage);
            _post(_sendMessage);
            _sendSemaphore.Release();
            ConsoleHelper.WriteToConsole("1 поток", "Данные переданы");
            _receiveSemaphore.WaitOne();

            Buffer buffer = new Buffer();
            buffer.receipt = _receivedMessage;
           
            if(buffer.receipt == null)
            {
                Thread.Sleep(3000);
                if (buffer.receipt == null)
                {
                    ConsoleHelper.WriteToConsole("1 поток", "Отправляю повторно");
                    Frame.GenerateData(_sendMessage);
                    _post(_sendMessage);
                }
                else
                {
                    ConsoleHelper.WriteToConsoleReceipt("Квитанция от 2 потока", buffer.receipt);
                }
            }
            else
            {
                ConsoleHelper.WriteToConsoleReceipt("Квитанция от 2 потока", buffer.receipt);
            }

            _sendSemaphore.Release();
        }
        public void ReceiveData(BitArray array)
        {
            _receivedMessage = array;
        }

    }
}
