using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace Magic___Scroll
{
    class Son
    {
        SoundEffect bgEffect;
        SoundEffectInstance instance;

        public void Initialize(ContentManager content, string nomDuSon, bool tourneEnBoucle)
        {
            bgEffect = content.Load<SoundEffect>(nomDuSon);
            instance = bgEffect.CreateInstance();
            instance.IsLooped = tourneEnBoucle;
            instance.Play();
        }
        public void Lire()
        {
            bgEffect.Play(0.1f, 0.0f, 0.0f);
        }
        public void Reprendre()
        {
            if (instance.State == SoundState.Paused)
                instance.Resume();
        }
        public void Pause()
        {
            if (instance.State == SoundState.Playing)
                instance.Pause();
        }
        public void Stop()
        {
            instance.Stop();
        }
    }
}
