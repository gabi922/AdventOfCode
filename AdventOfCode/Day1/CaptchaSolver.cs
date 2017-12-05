namespace AdventOfCode2017.Day1
{
    public class CaptchaSolver
    {
        public int GetCaptchaSum(string captcha, int step)
        {
            int sum = 0;

            for (int i = 0; i < captcha.Length; i++)
            {
                if (captcha[i] == captcha[(i + step) % captcha.Length])
                {
                    sum += captcha[i] - '0';
                }
            }

            return sum;
        }
    }
}
