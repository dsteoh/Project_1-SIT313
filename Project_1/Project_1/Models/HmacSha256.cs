using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Crypto.Parameters;
using System;

namespace Project_1.Models
{
    /// <summary>
    /// This class computes our HMACSHA256 HASH
    /// Reference taken from https://stackoverflow.com/questions/36876641/generate-hmac-sha256-hash-with-bouncycastle/36879373#36879373
    /// </summary>
    class HmacSha256
    {
        private readonly HMac _hmac;

        public HmacSha256(byte[] key)
        {
            _hmac = new HMac(new Sha256Digest());
            _hmac.Init(new KeyParameter(key));
        }
        /// <summary>
        /// This method computes and returns the hash in bytes
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public byte[] ComputeHash(byte[] value)
        {
            if (value == null) throw new ArgumentNullException("value");
            byte[] resBuf = new byte[_hmac.GetMacSize()];
            _hmac.BlockUpdate(value, 0, value.Length);
            _hmac.DoFinal(resBuf, 0);

            return resBuf;
        }
    }
}
