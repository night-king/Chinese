using Xunit;

namespace Chinese.Test
{
    public class PinyinTest
    {
        [Fact]
        public void Test1()
        {
            var str = "免费，跨平台，开源！";
            Assert.Equal("mian3 fei4，kua4 ping2 tai1，kai1 yuan2！", Pinyin.GetString(str, PinyinFormat.Default));
            Assert.Equal("mian fei，kua ping tai，kai yuan！", Pinyin.GetString(str, PinyinFormat.WithoutTone));
            Assert.Equal("miǎn fèi，kuà píng tāi，kāi yuán！", Pinyin.GetString(str, PinyinFormat.PhoneticSymbol));
        }

        [Fact]
        public void ChineseLexiconTest()
        {
            var str = "他是重量级选手。";
            Assert.Equal("ta1 shi4 chong2 liang2 ji2 shua1 shou3。", Pinyin.GetString(str, PinyinFormat.Default));

            var words = new ChineseWord[]
            {
                new ChineseWord { Pinyin = "zhong4 liang4", Simplified = "重量", Traditional = "重量" },
            };

            using (new ChineseLexicon(words))
            {
                Assert.Equal("ta1 shi4 zhong4 liang4 ji2 shua1 shou3。", Pinyin.GetString(str, PinyinFormat.Default));
            }
        }

    }
}
