# Sparse Arrays

There is a collection of input strings and a collection of query strings. For each query string, determine how many times it occurs in the list of input strings. Return an array of the results.

Input format:

- The first line contains and integer n, the size of stringList.
- Each of the next n lines contains a string stringList[i].
- The next line contains q, the size of queryList.
- Each of the next n lines contains a string queryList[i].

Input sample:

String list:
```
abcde
sdaklfj
asdjf
na
basdn
sdaklfj
asdjf
na
asdjf
na
basdn
sdaklfj
asdjf
```

Query list:
```
abcde
sdaklfj
asdjf
na
basdn
```

Output:
```
1
3
4
3
2
```

For more information, consult [Hackerhank challenge page](https://www.hackerrank.com/challenges/sparse-arrays/problem).