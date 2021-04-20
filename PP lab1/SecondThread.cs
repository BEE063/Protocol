using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using ThreadsEdu;

namespace PP_lab1
{
    public class SecondThread
    {
        private Semaphore _sendSemaphore;
        private Semaphore _receiveSemaphore;
        private BitArray _receivedMessage;
        private BitArray _receiptMessage;
        private PostToFirstWT _post;
        private bool _dataIsReceived = false;


        public SecondThread(ref Semaphore sendSemaphore, ref Semaphore receiveSemaphore)
        {
            _sendSemaphore = sendSemaphore;
            _receiveSemaphore = receiveSemaphore;
        }
        public void SecondThreadMain(Object obj)
        {
            _post = (PostToFirstWT)obj;
            _receiveSemaphore.WaitOne();

            _receiptMessage = new BitArray(1);

            
            Buffer buffer = new Buffer(_receivedMessage);
            if (buffer.ReceiveFrame() != null && _dataIsReceived==true)
            {
                ConsoleHelper.WriteToConsoleArray("2 поток данные", buffer.ReceiveFrame());
                Frame.GenerateReceipt(_receiptMessage, true);
                _dataIsReceived = false;
            }
            else
            {
                Frame.GenerateReceipt(_receiptMessage, false);
            }
           
            _post(_receiptMessage);

            _sendSemaphore.Release();
            _receiveSemaphore.WaitOne();
            if (_dataIsReceived == true)
            {
                ConsoleHelper.WriteToConsoleArray("2 поток данные", buffer.ReceiveFrame());
                Frame.GenerateReceipt(_receiptMessage, true);
                _sendSemaphore.Release();
            }
        }
        public void ReceiveData(BitArray array)
        {
            _receivedMessage = array;
            _dataIsReceived = true;
        }
    }
}
