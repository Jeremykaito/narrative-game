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
        static const AkUniqueID PLAY_COUP_DE_FIL = 2526429843U;
        static const AkUniqueID PLAY_MUSIC = 2932040671U;
        static const AkUniqueID PLAY_PALAIS_MENTAL = 4113650174U;
        static const AkUniqueID SET_COUP_DE_FIL_STEP0 = 1722557384U;
        static const AkUniqueID SET_COUP_DE_FIL_STEP1 = 1722557385U;
        static const AkUniqueID SET_COUP_DE_FIL_STEP2 = 1722557386U;
        static const AkUniqueID SET_COUP_DE_FIL_STEP3 = 1722557387U;
        static const AkUniqueID SET_MUSIC_COUP_DE_FIL = 1947713803U;
        static const AkUniqueID SET_MUSIC_PALAIS_MENTAL = 1357233606U;
        static const AkUniqueID SET_STATE_EXPLORING = 2951726260U;
        static const AkUniqueID SET_STATE_SPEAKING = 625636842U;
        static const AkUniqueID STOP_MUSIC = 2837384057U;
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
                static const AkUniqueID STEP0 = 1718617341U;
                static const AkUniqueID STEP1 = 1718617340U;
                static const AkUniqueID STEP2 = 1718617343U;
                static const AkUniqueID STEP3 = 1718617342U;
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
                static const AkUniqueID COUP_DE_FIL_STEP0 = 264031245U;
                static const AkUniqueID COUP_DE_FIL_STEP1 = 264031244U;
                static const AkUniqueID COUP_DE_FIL_STEP2 = 264031247U;
                static const AkUniqueID COUP_DE_FIL_STEP3 = 264031246U;
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
