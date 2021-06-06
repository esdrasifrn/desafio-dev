﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Desafio.Test.Factories
{
    public class ArquivoCNABFactory
    {
        public static Stream GetArquivoCNABValido()
        {
            var arquivoBase64 = "MzIwMTkwMzAxMDAwMDAxNDIwMDA5NjIwNjc2MDE3NDc1MyoqKiozMTUzMTUzNDUzSk/Dg08gTUFDRURPICAgQkFSIERPIEpPw4NPICAgICAgIAo1MjAxOTAzMDEwMDAwMDEzMjAwNTU2NDE4MTUwNjMzMTIzKioqKjc2ODcxNDU2MDdNQVJJQSBKT1NFRklOQUxPSkEgRE8gw5MgLSBNQVRSSVoKMzIwMTkwMzAxMDAwMDAxMjIwMDg0NTE1MjU0MDczNjc3NyoqKioxMzEzMTcyNzEyTUFSQ09TIFBFUkVJUkFNRVJDQURPIERBIEFWRU5JREEKMjIwMTkwMzAxMDAwMDAxMTIwMDA5NjIwNjc2MDE3MzY0OCoqKiowMDk5MjM0MjM0Sk/Dg08gTUFDRURPICAgQkFSIERPIEpPw4NPICAgICAgIAoxMjAxOTAzMDEwMDAwMDE1MjAwMDk2MjA2NzYwMTcxMjM0KioqKjc4OTAyMzMwMDBKT8ODTyBNQUNFRE8gICBCQVIgRE8gSk/Dg08gICAgICAgCjIyMDE5MDMwMTAwMDAwMTA3MDA4NDUxNTI1NDA3Mzg3MjMqKioqOTk4NzEyMzMzM01BUkNPUyBQRVJFSVJBTUVSQ0FETyBEQSBBVkVOSURBCjIyMDE5MDMwMTAwMDAwNTAyMDA4NDUxNTI1NDA3Mzg0NzMqKioqMTIzMTIzMTIzM01BUkNPUyBQRVJFSVJBTUVSQ0FETyBEQSBBVkVOSURBCjMyMDE5MDMwMTAwMDAwNjAyMDAyMzI3MDI5ODA1NjY3NzcqKioqMTMxMzE3MjcxMkpPU8OJIENPU1RBICAgIE1FUkNFQVJJQSAzIElSTcODT1MKMTIwMTkwMzAxMDAwMDAyMDAwMDU1NjQxODE1MDYzMTIzNCoqKiozMzI0MDkwMDAyTUFSSUEgSk9TRUZJTkFMT0pBIERPIMOTIC0gTUFUUklaCjUyMDE5MDMwMTAwMDAwODAyMDA4NDUxNTI1NDA3MzMxMjMqKioqNzY4NzE0NTYwN01BUkNPUyBQRVJFSVJBTUVSQ0FETyBEQSBBVkVOSURBCjIyMDE5MDMwMTAwMDAwMTAyMDAyMzI3MDI5ODA1Njg0NzMqKioqMTIzMTIzMTIzM0pPU8OJIENPU1RBICAgIE1FUkNFQVJJQSAzIElSTcODT1MKMzIwMTkwMzAxMDAwMDYxMDIwMDIzMjcwMjk4MDU2Njc3NyoqKioxMzEzMTcyNzEySk9Tw4kgQ09TVEEgICAgTUVSQ0VBUklBIDMgSVJNw4NPUwo0MjAxOTAzMDEwMDAwMDE1MjMyNTU2NDE4MTUwNjMxMjM0KioqKjY2NzgxMDAwMDBNQVJJQSBKT1NFRklOQUxPSkEgRE8gw5MgLSBGSUxJQUwKODIwMTkwMzAxMDAwMDAxMDIwMzg0NTE1MjU0MDczMjM0NCoqKioxMjIyMTIzMjIyTUFSQ09TIFBFUkVJUkFNRVJDQURPIERBIEFWRU5JREEKMzIwMTkwMzAxMDAwMDAxMDMwMDIzMjcwMjk4MDU2Njc3NyoqKioxMzEzMTcyNzEySk9Tw4kgQ09TVEEgICAgTUVSQ0VBUklBIDMgSVJNw4NPUwo5MjAxOTAzMDEwMDAwMDEwMjAwNTU2NDE4MTUwNjM2MjI4KioqKjkwOTAwMDAwMDBNQVJJQSBKT1NFRklOQUxPSkEgRE8gw5MgLSBNQVRSSVoKNDIwMTkwNjAxMDAwMDA1MDYxNzg0NTE1MjU0MDczMTIzNCoqKioyMjMxMTAwMDAwTUFSQ09TIFBFUkVJUkFNRVJDQURPIERBIEFWRU5JREEKMjIwMTkwMzAxMDAwMDAxMDkwMDIzMjcwMjk4MDU2ODcyMyoqKio5OTg3MTIzMzMzSk9Tw4kgQ09TVEEgICAgTUVSQ0VBUklBIDMgSVJNw4NPUwo4MjAxOTAzMDEwMDAwMDAwMjAwODQ1MTUyNTQwNzMyMzQ0KioqKjEyMjIxMjMyMjJNQVJDT1MgUEVSRUlSQU1FUkNBRE8gREEgQVZFTklEQQoyMjAxOTAzMDEwMDAwMDAwNTAwMjMyNzAyOTgwNTY3Njc3KioqKjg3NzgxNDE4MDhKT1PDiSBDT1NUQSAgICBNRVJDRUFSSUEgMyBJUk3Dg09TCjMyMDE5MDMwMTAwMDAwMTkyMDA4NDUxNTI1NDA3MzY3NzcqKioqMTMxMzE3MjcxMk1BUkNPUyBQRVJFSVJBTUVSQ0FETyBEQSBBVkVOSURBCg==";
            var fromBase64 = Convert.FromBase64String(arquivoBase64);
            
            return new MemoryStream(fromBase64);
        }

        public static int GetNumeroLinhasStream()
        {
            List<string> linhas = new List<string>();

            using StreamReader reader = new StreamReader(GetArquivoCNABValido());
            while (!reader.EndOfStream)
            {
                linhas.Add(reader.ReadLine());
            }

            return linhas.Count;
        }
    }
}
