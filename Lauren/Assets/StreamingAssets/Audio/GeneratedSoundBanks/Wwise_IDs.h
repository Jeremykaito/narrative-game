/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audiokinetic Wwise generated include file. Do not edit.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef __WWISE_IDS_H__
#define __WWISE_IDS_H__

#include <AK/SoundEngine/Common/AkTypes.h>

namespace AK
{
    namespace EVENTS
    {
        static const AkUniqueID INIT_ALL_STATES = 3327006228U;
        static const AkUniqueID LPF_EFFECT = 1505908803U;
        static const AkUniqueID PLAY_C1 = 2346744638U;
        static const AkUniqueID PLAY_C2 = 2346744637U;
        static const AkUniqueID PLAY_C3 = 2346744636U;
        static const AkUniqueID PLAY_C4 = 2346744635U;
        static const AkUniqueID PLAY_COUP_DE_FIL = 2526429843U;
        static const AkUniqueID PLAY_MUSIC = 2932040671U;
        static const AkUniqueID PLAY_PALAIS_MENTAL = 4113650174U;
        static const AkUniqueID SET_STATE_EXPLORING = 2951726260U;
        static const AkUniqueID SET_STATE_SPEAKING = 625636842U;
        static const AkUniqueID STOP_MUSIC = 2837384057U;
        static const AkUniqueID SWITCH_MUSIC_COUP_DE_FIL = 1379977405U;
        static const AkUniqueID SWITCH_MUSIC_PALAIS_MENTAL = 606726776U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace GAME_STATES
        {
            static const AkUniqueID GROUP = 2721494480U;

            namespace STATE
            {
                static const AkUniqueID EXPLORING = 1823678183U;
                static const AkUniqueID SPEAKING = 2418513123U;
            } // namespace STATE
        } // namespace GAME_STATES

        namespace STATE_COUP_DE_FIL
        {
            static const AkUniqueID GROUP = 3725819248U;

            namespace STATE
            {
                static const AkUniqueID STEP1 = 1718617340U;
                static const AkUniqueID STEP2 = 1718617343U;
                static const AkUniqueID STEP3 = 1718617342U;
                static const AkUniqueID STEP4 = 1718617337U;
            } // namespace STATE
        } // namespace STATE_COUP_DE_FIL

    } // namespace STATES

    namespace SWITCHES
    {
        namespace COUP_DE_FIL__STEPS
        {
            static const AkUniqueID GROUP = 2203862337U;

            namespace SWITCH
            {
                static const AkUniqueID C1 = 1853303301U;
                static const AkUniqueID C2 = 1853303302U;
                static const AkUniqueID C3 = 1853303303U;
                static const AkUniqueID C4 = 1853303296U;
            } // namespace SWITCH
        } // namespace COUP_DE_FIL__STEPS

        namespace SWITCH_GROUP__MEMORIES
        {
            static const AkUniqueID GROUP = 3272534494U;

            namespace SWITCH
            {
                static const AkUniqueID COUP_DE_FIL = 1174450734U;
                static const AkUniqueID PALAIS_MENTAL = 866457171U;
            } // namespace SWITCH
        } // namespace SWITCH_GROUP__MEMORIES

    } // namespace SWITCHES

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID MAIN_SOUNDBANK = 2228651116U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
        static const AkUniqueID MUSIC = 3991942870U;
        static const AkUniqueID SFX = 393239870U;
        static const AkUniqueID VOICE = 3170124113U;
    } // namespace BUSSES

    namespace AUDIO_DEVICES
    {
        static const AkUniqueID NO_OUTPUT = 2317455096U;
        static const AkUniqueID SYSTEM = 3859886410U;
    } // namespace AUDIO_DEVICES

}// namespace AK

#endif // __WWISE_IDS_H__
