namespace Coding.Challenges.DataStructures.Huffman_Decoding;

public class HuffmanDecoding
{
    class HuffmanNode
    {
        public string? value { get; set; }
        public int count { get; set; } = 0;
        public HuffmanNode? left { get; set; }
        public HuffmanNode? right { get; set; }
    }

    static string decode_huff(HuffmanNode root, HuffmanNode node, string encoded)
    {
        if (node == null)
        {
            return "";
        }

        if (!string.IsNullOrEmpty(node.value))
        {
            return node.value + "" + decode_huff(root, root, encoded);
        }

        if (string.IsNullOrEmpty(encoded))
        {
            return "";
        }

        var nextEncoded = encoded.Length == 1 ? "" : string.Concat(encoded.Skip(1));
        if (encoded.First() == '0')
        {
            return decode_huff(root, node.left, nextEncoded);
        }

        return decode_huff(root, node.right, nextEncoded);
    }

    static HuffmanNode create_huff(string plainText)
    {
        if (plainText == null)
        {
            throw new ArgumentNullException(nameof(plainText));
        }

        var charcterAndCount = new Dictionary<char, int>();

        foreach (char letter in plainText)
        {
            if (charcterAndCount.ContainsKey(letter))
            {
                charcterAndCount[letter]++;
            }
            else
            {
                charcterAndCount[letter] = 1;
            }
        }

        List<HuffmanNode> minHeap = charcterAndCount.OrderBy(x => x.Value)
                        .Select(x => new HuffmanNode() { value = x.Key.ToString(), count = x.Value })
                        .ToList();

        while (minHeap.Count() != 1)
        {
            var left = minHeap.First();
            minHeap.Remove(left!);

            var right = minHeap.First();
            minHeap.Remove(right!);

            var top = new HuffmanNode() { count = right.count + left.count };
            top.left = left;
            top.right = right;

            minHeap.Add(top);
            minHeap = minHeap.OrderBy(x => x.value).ToList();
        }
        return minHeap.First();
    }

    static string get_encoded_from_huff(HuffmanNode node, string text)
    {
        var result = "";
        foreach (char letter in text)
        {
            result += get_char_code(node, "", letter);
        }
        return result;
    }

    static string get_char_code(HuffmanNode? root, string encode, char character)
    {
        if (root == null)
        {
            return "";
        }

        if (root.value == character.ToString())
        {
            return encode;
        }

        return get_char_code(root.left, encode + "0", character) + "" + get_char_code(root.right, encode + "1", character);
    }

    static void Main(String[] args)
    {
        var plainText = Console.ReadLine() ?? "";

        var huffmanNode = create_huff(plainText);
        var encodedText = get_encoded_from_huff(huffmanNode, plainText);
        var decoded = decode_huff(huffmanNode, huffmanNode, encodedText);

        Console.WriteLine(decoded);
    }
}
