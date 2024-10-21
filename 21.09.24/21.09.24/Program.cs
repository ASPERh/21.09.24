using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
abstract class StorageDevice
{
    public string Name { get; set; }
    public string Manufacturer { get; set; }
    public string Model { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public StorageDevice(string name, string manufacturer, string model, int quantity, decimal price)
    {
        Name = name;
        Manufacturer = manufacturer;
        Model = model;
        Quantity = quantity;
        Price = price;
    }

    public virtual void Print()
    {
        Console.WriteLine($"Имя: {Name}, Производитель: {Manufacturer}, Модель: {Model}, Кол-во: {Quantity}, Цена: {Price}");
    }

    public virtual void LoadFromFile(string filename)
    {
        Console.WriteLine("Загрузка из файла...");
    }

    public virtual void SaveToFile(string filename)
    {
        Console.WriteLine("Сохранение в файл...");
    }
}

class FlashMemory : StorageDevice
{
    public int MemorySize { get; set; }
    public int UsbSpeed { get; set; }

    public FlashMemory(string name, string manufacturer, string model, int quantity, decimal price, int memorySize, int usbSpeed)
        : base(name, manufacturer, model, quantity, price)
    {
        MemorySize = memorySize;
        UsbSpeed = usbSpeed;
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Объём памяти: {MemorySize} GB, USB Скоррость: {UsbSpeed} MB/s");
    }
}

class DVD : StorageDevice
{
    public int ReadSpeed { get; set; }
    public int WriteSpeed { get; set; }

    public DVD(string name, string manufacturer, string model, int quantity, decimal price, int readSpeed, int writeSpeed)
        : base(name, manufacturer, model, quantity, price)
    {
        ReadSpeed = readSpeed;
        WriteSpeed = writeSpeed;
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Скорость чтения: {ReadSpeed}, Скорость записи: {WriteSpeed}");
    }
}

class HDD : StorageDevice
{
    public int DiskSize { get; set; }
    public int UsbSpeed { get; set; }

    public HDD(string name, string manufacturer, string model, int quantity, decimal price, int diskSize, int usbSpeed)
        : base(name, manufacturer, model, quantity, price)
    {
        DiskSize = diskSize;
        UsbSpeed = usbSpeed;
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Размер диска: {DiskSize} GB, USB Скорость: {UsbSpeed} MB/s");
    }
}

class Program
{
    static List<StorageDevice> devices = new List<StorageDevice>();

    static void Main(string[] args)
    {
        AddDevice(new FlashMemory("Flash Drive", "Samsung", "MUF-64DA/APC", 10, 500, 64, 150));
        AddDevice(new DVD("DVD-RW", "Asus", "08D2S-U LITE", 5, 150, 16, 8));
        AddDevice(new HDD("External HDD", "Seagate Savvio", "ST9300653SS", 2, 2000, 1000, 500));

        Console.WriteLine("Перечень устройств:");
        PrintDevices();

        RemoveDevice("Flash Drive");

        Console.WriteLine("\nПосле удаления Flash Drive:");
        PrintDevices();
    }

    static void AddDevice(StorageDevice device)
    {
        devices.Add(device);
    }

    static void RemoveDevice(string name)
    {
        devices.RemoveAll(d => d.Name == name);
    }

    static void PrintDevices()
    {
        foreach (var device in devices)
        {
            device.Print();
            Console.WriteLine();
        }
    }

    static StorageDevice FindDevice(string name)
    {
        return devices.FirstOrDefault(d => d.Name == name);
    }

    static void UpdateDevice(string name, string newModel, int newQuantity, decimal newPrice)
    {
        var device = FindDevice(name);
        if (device != null)
        {
            device.Model = newModel;
            device.Quantity = newQuantity;
            device.Price = newPrice;
            Console.WriteLine($"Обновлено {name}");
        }
        else
        {
            Console.WriteLine($"Устройство {name} не найдено");
        }
    }
}