namespace AofCode21;

using System;
using System.Collections.Generic;

//https://adventofcode.com/2021/day/16
public class Day16
{
    public static Int64 FirstStar(IEnumerable<string> input)
    {
        var binary = HexToBinary(input.First());

        var packets = Packet.Parse(binary).ToList();
        return packets.Sum(p => p.VersionSum);
    }

    public static Int64 SecondStar(IEnumerable<string> input)
    {
        var binary = HexToBinary(input.First());

        var packets = Packet.Parse(binary).ToList();
        return packets.First().Value;
    }

    private static string HexToBinary(string hex)
    {
        return string.Join(string.Empty, hex.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));
    }

    private static int BinaryToInt(IEnumerable<char> bin)
    {
        return Convert.ToInt32(new string(bin.ToArray()),2);
    }

    private static Int64 BinaryToInt64(IEnumerable<char> bin)
    {
        return Convert.ToInt64(new string(bin.ToArray()),2);
    }

    private static string TruncateLeft(string str, int characters)
    {
        return new string(str.Skip(characters).ToArray());
    }

    [PacketType(0)]
    public class SumPacket : OperatorPacket
    {
        public override Int64 Value => SubPackets.Sum(p => p.Value);
    }

    [PacketType(1)]
    public class ProductPacket : OperatorPacket
    {
        public override Int64 Value => SubPackets.Aggregate(1L, (a,p) => a * p.Value);
    }

    [PacketType(2)]
    public class MinimumPacket : OperatorPacket
    {
        public override Int64 Value => SubPackets.Min(p => p.Value);
    }

    [PacketType(3)]
    public class MaximumPacket : OperatorPacket
    {
        public override Int64 Value => SubPackets.Max(p => p.Value);
    }

    [PacketType(5)]
    public class GreaterThanPacket : ComparisonPacket
    {
        public override Int64 Value => SubPackets.First().Value > SubPackets.Last().Value ? 1 : 0;
    }

    [PacketType(6)]
    public class LessThanPacket : ComparisonPacket
    {
        public override Int64 Value => SubPackets.First().Value < SubPackets.Last().Value ? 1 : 0;
    }

    [PacketType(7)]
    public class EqualToPacket : ComparisonPacket
    {
        public override Int64 Value => SubPackets.First().Value == SubPackets.Last().Value ? 1 : 0;
    }

    public abstract class ComparisonPacket : OperatorPacket
    {
        protected override void ReadData(string data)
        {
            base.ReadData(data);

            if(SubPackets.Count() != 2)
                throw new InvalidOperationException($"Invalid number of sub packets {SubPackets.Count()} in comparison packet.");
        }
    }

    public abstract class OperatorPacket : Packet
    {
        public override int VersionSum => base.VersionSum + SubPackets.Sum(p => p.VersionSum);

        protected override void ReadData(string data)
        {
            base.ReadData(data);

            var lengthType = data.Skip(BitsRead).First();
            BitsRead += 1;
            if(lengthType == '0')
            {
                var length = BinaryToInt(data.Skip(BitsRead).Take(15));
                BitsRead += 15;
                SubPackets = Packet.Parse(data.Skip(BitsRead).Take(length)).ToList();                
            }
            else
            {
                var pCount = BinaryToInt(data.Skip(BitsRead).Take(11));
                BitsRead += 11;
                SubPackets = Packet.Parse(data.Skip(BitsRead), pCount).ToList();
            }

            BitsRead += SubPackets.Sum(p => p.BitsRead);
        }

        public IEnumerable<Packet> SubPackets {get; private set;} = Enumerable.Empty<Packet>();
    }

    [PacketType(4)]
    public class LiteralPacket : Packet
    {
        private Int64 _value = 0;
        public override Int64 Value => _value;

        protected override void ReadData(string data)
        {
            base.ReadData(data);

            var readMore = true;
            var digits = new List<Char>();
            while(readMore)
            {

                readMore = data.Skip(BitsRead).First() == '1';
                BitsRead++;
                digits.AddRange(data.Skip(BitsRead).Take(4));
                BitsRead += 4;
            }
            _value = BinaryToInt64(digits);
        }
    }

    public abstract class Packet
    {
        public int Version {get; private set; }

        public int TypeId {get; private set;}

        public int BitsRead {get; protected set;}

        public virtual int VersionSum => Version;

        public abstract Int64 Value {get;}

        protected virtual void ReadData(string data)
        {
            TypeId = BinaryToInt(new string(data.Skip(3).Take(3).ToArray()).PadLeft(0));
            Version = BinaryToInt(new string(data.Take(3).ToArray()).PadLeft(0));

            BitsRead += 6;
        }

        public static IEnumerable<Packet> Parse(IEnumerable<char> data, int maxPackets = int.MaxValue)
        {
            return Parse(new string(data.ToArray()), maxPackets);
        }
        public static IEnumerable<Packet> Parse(string data, int maxPackets = int.MaxValue)
        {
            var packets = new List<Packet>();
            while(data.Length > 7 && packets.Count() < maxPackets)
            {
                var typeId = BinaryToInt(new string(data.Skip(3).Take(3).ToArray()).PadLeft(0));

                var packetType = typeof(Packet).Assembly.GetTypes().First(t => 
                    typeof(Packet).IsAssignableFrom(t) 
                    && t.GetCustomAttributes(typeof(PacketType),false).Cast<PacketType>().Any(pt => pt.Id == typeId));

                var packet = Activator.CreateInstance(packetType) as Packet ?? throw new InvalidOperationException("Cannot create packet");
                packet.ReadData(data);
                data = TruncateLeft(data, packet.BitsRead);
                packets.Add(packet);
            }
            return packets;
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class PacketType : Attribute
    {
        public int Id { get; }

        public PacketType(int id)
        {
            Id = id;
        }
    }
}
