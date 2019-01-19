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
        static const AkUniqueID PLAY_C5 = 2346744634U;
        static const AkUniqueID PLAY_COUP_DE_FIL = 2526429843U;
        static const AkUniqueID PLAY_F1 = 2262856449U;
        static const AkUniqueID PLAY_F2 = 2262856450U;
        static const AkUniqueID PLAY_F3 = 2262856451U;
        static const AkUniqueID PLAY_F4 = 2262856452U;
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
        namespace COUP_DE_FIL
        {
            static const AkUniqueID GROUP = 1174450734U;

            namespace STATE
            {
                static const AkUniqueID STEP1 = 1718617340U;
                static const AkUniqueID STEP2 = 1718617343U;
                static const AkUniqueID STEP3 = 1718617342U;
                static const AkUniqueID STEP4 = 1718617337U;
            } // namespace STATE
        } // namespace COUP_DE_FIL

        namespace FEU_DE_CAMP
        {
            static const AkUniqueID GROUP = 791499361U;

            namespace STATE
            {
                static const AkUniqueID STEP1 = 1718617340U;
                static const AkUniqueID STEP2 = 1718617343U;
                static const AkUniqueID STEP3 = 1718617342U;
                static const AkUniqueID STEP4 = 1718617337U;
            } // namespace STATE
        } // namespace FEU_DE_CAMP

        namespace GAME_STATES
        {
            static const AkUniqueID GROUP = 2721494480U;

            namespace STATE
            {
                static const AkUniqueID EXPLORING = 1823678183U;
                static const AkUniqueID SPEAKING = 2418513123U;
            } // namespace STATE
        } // namespace GAME_STATES

    } // namespace STATES

    namespace SWITCHES
    {
        namespace COUP_DE_FIL
        {
            static const AkUniqueID GROUP = 1174450734U;

            namespace SWITCH
            {
                static const AkUniqueID C1 = 1853303301U;
                static const AkUniqueID C2 = 1853303302U;
                static const AkUniqueID C3 = 1853303303U;
                static const AkUniqueID C4 = 1853303296U;
                static const AkUniqueID C5 = 1853303297U;
            } // namespace SWITCH
        } // namespace COUP_DE_FIL

        namespace FEU_DE_CAMP
        {
            static const AkUniqueID GROUP = 791499361U;

            namespace SWITCH
            {
                static const AkUniqueID F1 = 1802970442U;
                static const AkUniqueID F2 = 1802970441U;
                static const AkUniqueID F3 = 1802970440U;
                static const AkUniqueID F4 = 1802970447U;
                static const AkUniqueID F5 = 1802970446U;
            } // namespace SWITCH
        } // namespace FEU_DE_CAMP

        namespace SWITCH_GROUP_SCENES
        {
            static const AkUniqueID GROUP = 2703543839U;

            namespace SWITCH
            {
                static const AkUniqueID COUP_DE_FIL = 1174450734U;
                static const AkUniqueID FEU_DE_CAMP = 791499361U;
                static const AkUniqueID PALAIS_MENTAL = 866457171U;
            } // namespace SWITCH
        } // namespace SWITCH_GROUP_SCENES

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
