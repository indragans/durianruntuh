using UnityEngine;
using System.IO.Ports;

public class ArduinoDataReader : MonoBehaviour
{
    public string portName = "COM3"; // GANTI dengan port Arduino kamu
    public int baudRate = 9600;

    private SerialPort serialPort;
    public float CurrentX { get; private set; }

    void Start()
    {
        try
        {
            serialPort = new SerialPort(portName, baudRate);
            serialPort.Open();
            serialPort.ReadTimeout = 100;
            Debug.Log("Serial port terbuka!");
        }
        catch (System.Exception e)
        {
            Debug.LogError("Gagal membuka port: " + e.Message);
        }
    }

    void Update()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            try
            {
                string data = serialPort.ReadLine();
                string[] parts = data.Split(',');

                if (parts.Length >= 1 && float.TryParse(parts[0], out float xValue))
                {
                    CurrentX = xValue; // nilai X dari sensor
                }
            }
            catch (System.TimeoutException) { }
            catch (System.Exception e)
            {
                Debug.LogWarning("Serial read error: " + e.Message);
            }
        }
    }

    void OnApplicationQuit()
    {
        if (serialPort != null && serialPort.IsOpen)
            serialPort.Close();
    }
}
