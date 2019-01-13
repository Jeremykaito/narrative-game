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
        static const AkUniqueID LPF_EFFECT = 1505908803U;
        static const AkUniqueID PLAY_COUP_DE_FIL = 2526429843U;
        static const AkUniqueID PLAY_MUSIC = 2932040671U;
        static const AkUniqueID SET_COUP_DE_FIL_ITEM1 = 270700608U;
        static const AkUniqueID SET_COUP_DE_FIL_ITEM2 = 270700611U;
        static const AkUniqueID SET_COUP_DE_FIL_ITEM3 = 270700610U;
        static const AkUniqueID SET_MUSIC_COUP_DE_FIL = 1947713803U;
        static const AkUniqueID SET_MUSIC_PALAIS_MENTAL = 1357233606U;
        static const AkUniqueID SET_STATE_EXPLORING = 2951726260U;
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

        namespace STATE_GROUP__COUP_DE_FIL
        {
            static const AkUniqueID GROUP = 1749108375U;

            namespace STATE
            {
                static const AkUniqueID INTRO = 1125500713U;
                static const AkUniqueID ITEM1 = 2151963113U;
                static const AkUniqueID ITEM2 = 2151963114U;
                static const AkUniqueID ITEM3 = 2151963115U;
            } // namespace STATE
        } // namespace STATE_GROUP__COUP_DE_FIL

    } // namespace STATES

    namespace SWITCHES
    {
        namespace COUP_DE_FIL__STEPS
        {
            static const AkUniqueID GROUP = 2203862337U;

            namespace SWITCH
            {
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
