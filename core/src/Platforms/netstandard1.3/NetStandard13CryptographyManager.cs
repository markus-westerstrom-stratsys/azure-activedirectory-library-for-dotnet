﻿//----------------------------------------------------------------------
//
// Copyright (c) Microsoft Corporation.
// All rights reserved.
//
// This code is licensed under the MIT License.
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files(the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and / or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions :
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//
//------------------------------------------------------------------------------

using Microsoft.Identity.Core.Helpers;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Microsoft.Identity.Core
{
    internal class NetStandard13CryptographyManager : ICryptographyManager
    {
        public string CreateBase64UrlEncodedSha256Hash(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return null;
            }

            using (SHA256 sha = SHA256.Create())
            {
                UTF8Encoding encoding = new UTF8Encoding();
                return Base64UrlHelpers.Encode(sha.ComputeHash(encoding.GetBytes(input)));
            }
        }

        public string GenerateCodeVerifier()
        {
            byte[] buffer = new byte[Constants.CodeVerifierByteSize];
            using (var randomSource = RandomNumberGenerator.Create())
            {
                randomSource.GetBytes(buffer);
            }

            return Base64UrlHelpers.Encode(buffer);
        }

        public string CreateSha256Hash(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return null;
            }

            using (var sha256 = SHA256.Create())
            {
                var inputBytes = Encoding.UTF8.GetBytes(input);
                var outputBytes = sha256.ComputeHash(inputBytes);
                return Convert.ToBase64String(outputBytes);
            }
        }

        public string Encrypt(string message)
        {
            throw new NotImplementedException();
        }

        public string Decrypt(string encryptedMessage)
        {
            throw new NotImplementedException();
        }

        public byte[] Encrypt(byte[] message)
        {
            throw new NotImplementedException();
        }

        public byte[] Decrypt(byte[] encryptedMessage)
        {
            throw new NotImplementedException();
        }
    }
}
