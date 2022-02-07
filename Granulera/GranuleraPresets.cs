using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranuleraPresets : MonoBehaviour
{
    public enum GranuleraTemplate { template1, FlutterCrystals, Organ, NeonAbyss, DigitalRain, StereoCanonGenerator, Scriabin01 };

    private CsoundUnity csound;
    public GranuleraTemplate templateSelection;
    public bool applyOnStart = true;

    // Start is called before the first frame update
    void Start()
    {
        csound = GetComponent<CsoundUnity>();

        if (!applyOnStart) { return; }

        switch (templateSelection)
        {
            case GranuleraTemplate.template1:
                Template1();
                break;
            case GranuleraTemplate.FlutterCrystals:
                FlutterCrystals();
                break;
            case GranuleraTemplate.Organ:
                Organ();
                break;
            case GranuleraTemplate.NeonAbyss:
                NeonAbyss();
                break;
            case GranuleraTemplate.DigitalRain:
                DigitalRain();
                break;
            case GranuleraTemplate.StereoCanonGenerator:
                StereoCanonGenerator();
                break;
            case GranuleraTemplate.Scriabin01:
                Scriabin01();
                break;
        }
    }

    public void Template1()
    {
        //OSCILLATORS
        csound.SetChannel("WaveformSelection1", 1);
        csound.SetChannel("Oscillator1Volume", 1);
        csound.SetChannel("Oscillator1Semitone", 0);
        csound.SetChannel("Oscillator1Cents", 0);

        csound.SetChannel("WaveformSelection2", 1);
        csound.SetChannel("Oscillator2Volume", 1);
        csound.SetChannel("Oscillator2Semitone", 2);
        csound.SetChannel("Oscillator2Cents", 0);

        csound.SetChannel("WaveformSelection3", 1);
        csound.SetChannel("Oscillator3Volume", 1);
        csound.SetChannel("Oscillator3Semitone", 5);
        csound.SetChannel("Oscillator3Cents", 0);

        //GRANULATION
        csound.SetChannel("GrainSpread", 0.5f);

        csound.SetChannel("WindowingSelection", 2);
        csound.SetChannel("FrequencyVariationRange", 0);
        csound.SetChannel("FrequencyVariationRate", 0);
        csound.SetChannel("PitchVariation", 0);
        csound.SetChannel("GrainDuration", 0.35f);
        csound.SetChannel("DurationVariationRange", 0.152f);
        csound.SetChannel("DurationVariationRate", 3);
        csound.SetChannel("GrainDensity", 25);
        csound.SetChannel("DensityVariationRange", 18);
        csound.SetChannel("DensityVariationRate", 3.2f);
        csound.SetChannel("PhaseVariation", 1);

        //FILTER
        csound.SetChannel("FilterNoteTrack", 1);
        csound.SetChannel("FilterSelection", 1);
        csound.SetChannel("FilterFreq", 0.7f);
        csound.SetChannel("FilterRange", 0.0001f);
        csound.SetChannel("FilterReson", 1);
        csound.SetChannel("FilterBW", 1000);
        csound.SetChannel("FilterAttack", 0.01f);
        csound.SetChannel("FilterDecay", 1);
        csound.SetChannel("FilterSustain", 1);
        csound.SetChannel("FilterRelease", 0.1f);

        //LFOs
        csound.SetChannel("LfoFilterFreq", 0f);
        csound.SetChannel("LfoFilterRange", 0f);
        csound.SetChannel("LfoModAmpFreq", 0f);
        csound.SetChannel("LfoModAmpRange", 0f);

        //MODULATION
        csound.SetChannel("RMFreq", 612);
        csound.SetChannel("FMFreq", 2160);

        //GLOBALS
        csound.SetChannel("GlobalVolume", 0.1f);
        csound.SetChannel("GlobalPan", 0.5f);
        csound.SetChannel("GlobalTuning", 0.1f);

        //AMP ENVELOPE
        csound.SetChannel("AmpEnvelopeToggle", 0);
        csound.SetChannel("AmpAttack", 3.5f);
        csound.SetChannel("AmpDecay", 0.1f);
        csound.SetChannel("AmpSustain", 1f);
        csound.SetChannel("AmpRelease", 3.5f);

        //REVERB
        csound.SetChannel("ReverbBypass", 1);
        csound.SetChannel("ReverbSend", 1);
        csound.SetChannel("ReverbMix", 0.5f);
        csound.SetChannel("ReverbSize", 0.9f);

        //DELAY
        csound.SetChannel("DelayBypass", 1);
        csound.SetChannel("DelaySend", 0.45f);
        csound.SetChannel("DelayMix", 1);
        csound.SetChannel("DelayTimeLeft", 0.3f);
        csound.SetChannel("DelayTimeRight", 0.6f);
        csound.SetChannel("DelayFeedback", 0.75f);
    }

    public void FlutterCrystals()
    {
        //OSCILLATORS
        csound.SetChannel("WaveformSelection1", 1);
        csound.SetChannel("Oscillator1Volume", 1);
        csound.SetChannel("Oscillator1Semitone", 0);
        csound.SetChannel("Oscillator1Cents", 0);

        csound.SetChannel("WaveformSelection2", 2);
        csound.SetChannel("Oscillator2Volume", 0);
        csound.SetChannel("Oscillator2Semitone", 7);
        csound.SetChannel("Oscillator2Cents", 0);

        csound.SetChannel("WaveformSelection3", 4);
        csound.SetChannel("Oscillator3Volume", 0);
        csound.SetChannel("Oscillator3Semitone", 12);
        csound.SetChannel("Oscillator3Cents", 0);

        //GRANULATION
        csound.SetChannel("GrainSpread", 0.5f);

        csound.SetChannel("WindowingSelection", 4);
        csound.SetChannel("FrequencyVariationRange", 1);
        csound.SetChannel("FrequencyVariationRate", 0);
        csound.SetChannel("PitchVariation", 0);
        csound.SetChannel("GrainDuration", 0.07f);
        csound.SetChannel("DurationVariationRange", 0f);
        csound.SetChannel("DurationVariationRate", 3);
        csound.SetChannel("GrainDensity", 8f);
        csound.SetChannel("DensityVariationRange", 5.3f);
        csound.SetChannel("DensityVariationRate", 5.1f);
        csound.SetChannel("PhaseVariation", 0.05f);

        //FILTER
        csound.SetChannel("FilterNoteTrack", 1);
        csound.SetChannel("FilterSelection", 1);
        csound.SetChannel("FilterFreq", 1f);
        csound.SetChannel("FilterRange", 0.0001f);
        csound.SetChannel("FilterReson", 1);
        csound.SetChannel("FilterBW", 1000);
        csound.SetChannel("FilterAttack", 0.01f);
        csound.SetChannel("FilterDecay", 1);
        csound.SetChannel("FilterSustain", 1);
        csound.SetChannel("FilterRelease", 3f);

        //LFOs
        csound.SetChannel("LfoFilterFreq", 0f);
        csound.SetChannel("LfoFilterRange", 0f);
        csound.SetChannel("LfoModAmpFreq", 0f);
        csound.SetChannel("LfoModAmpRange", 0f);

        //MODULATION
        csound.SetChannel("RMFreq", 612);
        csound.SetChannel("FMFreq", 7989);
        csound.SetChannel("FMAmp", 0.03f);

        //GLOBALS
        csound.SetChannel("GlobalVolume", 0.35f);
        csound.SetChannel("GlobalPan", 0.5f);
        csound.SetChannel("GlobalTuning", 0.1f);

        //AMP ENVELOPE
        csound.SetChannel("AmpEnvelopeToggle", 0);
        csound.SetChannel("AmpAttack", 3f);
        csound.SetChannel("AmpDecay", 0.1f);
        csound.SetChannel("AmpSustain", 1f);
        csound.SetChannel("AmpRelease", 3f);

        //REVERB
        csound.SetChannel("ReverbBypass", 1);
        csound.SetChannel("ReverbSend", 1);
        csound.SetChannel("ReverbMix", 0.7f);
        csound.SetChannel("ReverbSize", 0.6f);

        //DELAY
        csound.SetChannel("DelayBypass", 1);
        csound.SetChannel("DelaySend", 0.8f);
        csound.SetChannel("DelayMix", 0.45f);
        csound.SetChannel("DelayTimeLeft", 0.11f);
        csound.SetChannel("DelayTimeRight", 0.17f);
        csound.SetChannel("DelayFeedback", 0.30f);
    }

    public void Organ()
    {
        //OSCILLATORS
        csound.SetChannel("WaveformSelection1", 2);
        csound.SetChannel("Oscillator1Volume", 0.65f);
        csound.SetChannel("Oscillator1Semitone", 0);
        csound.SetChannel("Oscillator1Cents", 0);

        csound.SetChannel("WaveformSelection2", 2);
        csound.SetChannel("Oscillator2Volume", 1);
        csound.SetChannel("Oscillator2Semitone", 12);
        csound.SetChannel("Oscillator2Cents", 0);

        csound.SetChannel("WaveformSelection3", 2);
        csound.SetChannel("Oscillator3Volume", 1);
        csound.SetChannel("Oscillator3Semitone", 19);
        csound.SetChannel("Oscillator3Cents", 0);

        //GRANULATION
        csound.SetChannel("GrainSpread", 0.5f);

        csound.SetChannel("WindowingSelection", 1);
        csound.SetChannel("FrequencyVariationRange", 1);
        csound.SetChannel("FrequencyVariationRate", 0);
        csound.SetChannel("PitchVariation", 0);
        csound.SetChannel("GrainDuration", 0.8f);
        csound.SetChannel("DurationVariationRange", 0.05f);
        csound.SetChannel("DurationVariationRate", 3.1f);
        csound.SetChannel("GrainDensity", 2f);
        csound.SetChannel("DensityVariationRange", 2f);
        csound.SetChannel("DensityVariationRate", 3.5f);
        csound.SetChannel("PhaseVariation", 1f);

        //FILTER
        csound.SetChannel("FilterNoteTrack", 1);
        csound.SetChannel("FilterSelection", 1);
        csound.SetChannel("FilterFreq", 0.037f);
        csound.SetChannel("FilterRange", 0.0001f);
        csound.SetChannel("FilterReson", 1);
        csound.SetChannel("FilterBW", 1000);
        csound.SetChannel("FilterAttack", 0.01f);
        csound.SetChannel("FilterDecay", 1);
        csound.SetChannel("FilterSustain", 1);
        csound.SetChannel("FilterRelease", 10f);

        //LFOs
        csound.SetChannel("LfoFilterFreq", 0f);
        csound.SetChannel("LfoFilterRange", 0f);
        csound.SetChannel("LfoModAmpFreq", 0f);
        csound.SetChannel("LfoModAmpRange", 0f);

        //MODULATION
        csound.SetChannel("RMFreq", 612);
        csound.SetChannel("RMAmp", 0f);
        csound.SetChannel("FMFreq", 7989);
        csound.SetChannel("FMAmp", 0f);

        //GLOBALS
        csound.SetChannel("GlobalVolume", 0.1f);
        csound.SetChannel("GlobalPan", 0.5f);
        csound.SetChannel("GlobalTuning", 0f);

        //AMP ENVELOPE
        csound.SetChannel("AmpEnvelopeToggle", 0);
        csound.SetChannel("AmpAttack", 0.5f);
        csound.SetChannel("AmpDecay", 0.1f);
        csound.SetChannel("AmpSustain", 1f);
        csound.SetChannel("AmpRelease", 1f);

        //REVERB
        csound.SetChannel("ReverbBypass", 1);
        csound.SetChannel("ReverbSend", 1);
        csound.SetChannel("ReverbMix", 1);
        csound.SetChannel("ReverbSize", 0.5f);

        //DELAY
        csound.SetChannel("DelayBypass", 1);
        csound.SetChannel("DelaySend", 1);
        csound.SetChannel("DelayMix", 1);
        csound.SetChannel("DelayTimeLeft", 0.37f);
        csound.SetChannel("DelayTimeRight", 0.7f);
        csound.SetChannel("DelayFeedback", 0.7f);
    }

    public void NeonAbyss()
    {
        //OSCILLATORS
        csound.SetChannel("WaveformSelection1", 3);
        csound.SetChannel("Oscillator1Volume", 1f);
        csound.SetChannel("Oscillator1Semitone", 0);
        csound.SetChannel("Oscillator1Cents", 0);

        csound.SetChannel("WaveformSelection2", 3);
        csound.SetChannel("Oscillator2Volume", 1f);
        csound.SetChannel("Oscillator2Semitone", 12);
        csound.SetChannel("Oscillator2Cents", 0);

        csound.SetChannel("WaveformSelection3", 3);
        csound.SetChannel("Oscillator3Volume", 1f);
        csound.SetChannel("Oscillator3Semitone", 19);
        csound.SetChannel("Oscillator3Cents", 0);

        //GRANULATION
        csound.SetChannel("GrainSpread", 0.5f);

        csound.SetChannel("WindowingSelection", 1);
        csound.SetChannel("FrequencyVariationRange", 1);
        csound.SetChannel("FrequencyVariationRate", 0);
        csound.SetChannel("PitchVariation", 0);
        csound.SetChannel("GrainDuration", 0.8f);
        csound.SetChannel("DurationVariationRange", 0.4f);
        csound.SetChannel("DurationVariationRate", 3.6f);
        csound.SetChannel("GrainDensity", 14f);
        csound.SetChannel("DensityVariationRange", 6f);
        csound.SetChannel("DensityVariationRate", 4f);
        csound.SetChannel("PhaseVariation", 0f);

        //FILTER
        csound.SetChannel("FilterNoteTrack", 1);
        csound.SetChannel("FilterSelection", 1);
        csound.SetChannel("FilterFreq", 0.5f);
        csound.SetChannel("FilterRange", 0.0001f);
        csound.SetChannel("FilterReson", 25f);
        csound.SetChannel("FilterBW", 1000);
        csound.SetChannel("FilterAttack", 0.01f);
        csound.SetChannel("FilterDecay", 1.63f);
        csound.SetChannel("FilterSustain", 0.055f);
        csound.SetChannel("FilterRelease", 10f);

        //LFOs
        csound.SetChannel("LfoFilterFreq", 0.11f);
        csound.SetChannel("LfoFilterRange", 0.15f);
        csound.SetChannel("LfoModAmpFreq", 0f);
        csound.SetChannel("LfoModAmpRange", 0f);

        //MODULATION
        csound.SetChannel("RMFreq", 2400);
        csound.SetChannel("RMAmp", 0f);
        csound.SetChannel("FMFreq", 7989);
        csound.SetChannel("FMAmp", 0f);

        //GLOBALS
        csound.SetChannel("GlobalVolume", 0.15f);
        csound.SetChannel("GlobalPan", 0.5f);
        csound.SetChannel("GlobalTuning", 0f);

        //AMP ENVELOPE
        csound.SetChannel("AmpEnvelopeToggle", 0);
        csound.SetChannel("AmpAttack", 0.1f);
        csound.SetChannel("AmpDecay", 0.1f);
        csound.SetChannel("AmpSustain", 1f);
        csound.SetChannel("AmpRelease", 3.2f);

        //REVERB
        csound.SetChannel("ReverbBypass", 1);
        csound.SetChannel("ReverbSend", 1);
        csound.SetChannel("ReverbMix", 0.33f);
        csound.SetChannel("ReverbSize", 0.9f);

        //DELAY
        csound.SetChannel("DelayBypass", 0);
        csound.SetChannel("DelaySend", 1);
        csound.SetChannel("DelayMix", 1);
        csound.SetChannel("DelayTimeLeft", 0.37f);
        csound.SetChannel("DelayTimeRight", 0.7f);
        csound.SetChannel("DelayFeedback", 0.7f);
    }

    public void DigitalRain()
    {
        //OSCILLATORS
        csound.SetChannel("WaveformSelection1", 2);
        csound.SetChannel("Oscillator1Volume", 0.84f);
        csound.SetChannel("Oscillator1Semitone", 0);
        csound.SetChannel("Oscillator1Cents", 0);

        csound.SetChannel("WaveformSelection2", 5);
        csound.SetChannel("Oscillator2Volume", 0.57f);
        csound.SetChannel("Oscillator2Semitone", 12);
        csound.SetChannel("Oscillator2Cents", 0);

        csound.SetChannel("WaveformSelection3", 5);
        csound.SetChannel("Oscillator3Volume", 0);
        csound.SetChannel("Oscillator3Semitone", 19);
        csound.SetChannel("Oscillator3Cents", 0);

        //GRANULATION
        csound.SetChannel("GrainSpread", 0.5f);

        csound.SetChannel("WindowingSelection", 6);
        csound.SetChannel("FrequencyVariationRange", 1);
        csound.SetChannel("FrequencyVariationRate", 0);
        csound.SetChannel("PitchVariation", 4.3f);
        csound.SetChannel("GrainDuration", 0.1f);
        csound.SetChannel("DurationVariationRange", 0.05f);
        csound.SetChannel("DurationVariationRate", 1.5f);
        csound.SetChannel("GrainDensity", 30.7f);
        csound.SetChannel("DensityVariationRange", 15f);
        csound.SetChannel("DensityVariationRate", 2f);
        csound.SetChannel("PhaseVariation", 1f);

        //FILTER
        csound.SetChannel("FilterNoteTrack", 1);
        csound.SetChannel("FilterSelection", 2);
        csound.SetChannel("FilterFreq", 0.136f);
        csound.SetChannel("FilterRange", 1);
        csound.SetChannel("FilterReson", 1);
        csound.SetChannel("FilterBW", 1000);
        csound.SetChannel("FilterAttack", 1.85f);
        csound.SetChannel("FilterDecay", 1.63f);
        csound.SetChannel("FilterSustain", 1);
        csound.SetChannel("FilterRelease", 10f);

        //LFOs
        csound.SetChannel("LfoFilterFreq", 0f);
        csound.SetChannel("LfoFilterRange", 0f);
        csound.SetChannel("LfoModAmpFreq", 0f);
        csound.SetChannel("LfoModAmpRange", 0f);

        //MODULATION
        csound.SetChannel("RMFreq", 0);
        csound.SetChannel("RMAmp", 0f);
        csound.SetChannel("FMFreq", 0);
        csound.SetChannel("FMAmp", 0f);

        //GLOBALS
        csound.SetChannel("GlobalVolume", 0.45f);
        csound.SetChannel("GlobalPan", 0.5f);
        csound.SetChannel("GlobalTuning", 0f);

        //AMP ENVELOPE
        csound.SetChannel("AmpEnvelopeToggle", 0);
        csound.SetChannel("AmpAttack", 2.15f);
        csound.SetChannel("AmpDecay", 5);
        csound.SetChannel("AmpSustain", 0.5f);
        csound.SetChannel("AmpRelease", 6f);

        //REVERB
        csound.SetChannel("ReverbBypass", 1);
        csound.SetChannel("ReverbSend", 1);
        csound.SetChannel("ReverbMix", 0.33f);
        csound.SetChannel("ReverbSize", 0.6f);

        //DELAY
        csound.SetChannel("DelayBypass", 0);
        csound.SetChannel("DelaySend", 1);
        csound.SetChannel("DelayMix", 1);
        csound.SetChannel("DelayTimeLeft", 0.37f);
        csound.SetChannel("DelayTimeRight", 0.7f);
        csound.SetChannel("DelayFeedback", 0.7f);
    }

    public void StereoCanonGenerator()
    {
        //OSCILLATORS
        csound.SetChannel("WaveformSelection1", 3);
        csound.SetChannel("Oscillator1Volume", 1);
        csound.SetChannel("Oscillator1Semitone", 0);
        csound.SetChannel("Oscillator1Cents", 0);

        csound.SetChannel("WaveformSelection2", 5);
        csound.SetChannel("Oscillator2Volume", 0);
        csound.SetChannel("Oscillator2Semitone", 12);
        csound.SetChannel("Oscillator2Cents", 0);

        csound.SetChannel("WaveformSelection3", 1);
        csound.SetChannel("Oscillator3Volume", 0);
        csound.SetChannel("Oscillator3Semitone", 19);
        csound.SetChannel("Oscillator3Cents", 0);

        //GRANULATION
        csound.SetChannel("GrainSpread", 0);

        csound.SetChannel("WindowingSelection", 1);
        csound.SetChannel("FrequencyVariationRange", 200);
        csound.SetChannel("FrequencyVariationRate", 3.5f);
        csound.SetChannel("PitchVariation", 1000f);
        csound.SetChannel("GrainDuration", 0.14f);
        csound.SetChannel("DurationVariationRange", 0);
        csound.SetChannel("DurationVariationRate", 0);
        csound.SetChannel("GrainDensity", 4);
        csound.SetChannel("DensityVariationRange", 0);
        csound.SetChannel("DensityVariationRate", 0);
        csound.SetChannel("PhaseVariation", 0f);

        //FILTER
        csound.SetChannel("FilterNoteTrack", 1);
        csound.SetChannel("FilterSelection", 1);
        csound.SetChannel("FilterFreq", 1);
        csound.SetChannel("FilterRange", 0.01f);
        csound.SetChannel("FilterReson", 1);
        csound.SetChannel("FilterBW", 1000);
        csound.SetChannel("FilterAttack", 0.01f);
        csound.SetChannel("FilterDecay", 0.01f);
        csound.SetChannel("FilterSustain", 1);
        csound.SetChannel("FilterRelease", 0.1f);

        //LFOs
        csound.SetChannel("LfoFilterFreq", 0f);
        csound.SetChannel("LfoFilterRange", 0f);
        csound.SetChannel("LfoModAmpFreq", 0.5f);
        csound.SetChannel("LfoModAmpRange", 0.5f);

        //MODULATION
        csound.SetChannel("RMFreq", 1200f);
        csound.SetChannel("RMAmp", 1f);
        csound.SetChannel("FMFreq", 0f);
        csound.SetChannel("FMAmp", 0f);

        //GLOBALS
        csound.SetChannel("GlobalVolume", 0.41f);
        csound.SetChannel("GlobalPan", 0.5f);
        csound.SetChannel("GlobalTuning", 0f);

        //AMP ENVELOPE
        csound.SetChannel("AmpEnvelopeToggle", 0);
        csound.SetChannel("AmpAttack", 0.01f);
        csound.SetChannel("AmpDecay", 0.01f);
        csound.SetChannel("AmpSustain", 1);
        csound.SetChannel("AmpRelease", 0.01f);

        //REVERB
        csound.SetChannel("ReverbBypass", 1);
        csound.SetChannel("ReverbSend", 1);
        csound.SetChannel("ReverbMix", 0.33f);
        csound.SetChannel("ReverbSize", 0.65f);

        //DELAY
        csound.SetChannel("DelayBypass", 1);
        csound.SetChannel("DelaySend", 1);
        csound.SetChannel("DelayMix", 1);
        csound.SetChannel("DelayTimeLeft", 2f);
        csound.SetChannel("DelayTimeRight", 4f);
        csound.SetChannel("DelayFeedback", 0f);
    }

    public void Scriabin01()
    {
        //OSCILLATORS
        csound.SetChannel("WaveformSelection1", 3);
        csound.SetChannel("Oscillator1Volume", 1f);
        csound.SetChannel("Oscillator1Semitone", 0);
        csound.SetChannel("Oscillator1Cents", 0);

        csound.SetChannel("WaveformSelection2", 3);
        csound.SetChannel("Oscillator2Volume", 0f);
        csound.SetChannel("Oscillator2Semitone", 12);
        csound.SetChannel("Oscillator2Cents", 0);

        csound.SetChannel("WaveformSelection3", 3);
        csound.SetChannel("Oscillator3Volume", 0f);
        csound.SetChannel("Oscillator3Semitone", 19);
        csound.SetChannel("Oscillator3Cents", 0);

        //GRANULATION
        csound.SetChannel("GrainSpread", 0.5f);

        csound.SetChannel("WindowingSelection", 1);
        csound.SetChannel("FrequencyVariationRange", 1);
        csound.SetChannel("FrequencyVariationRate", 0);
        csound.SetChannel("PitchVariation", 0);
        csound.SetChannel("GrainDuration", 0.15f);
        csound.SetChannel("DurationVariationRange", 0f);
        csound.SetChannel("DurationVariationRate", 3.6f);
        csound.SetChannel("GrainDensity", 14f);
        csound.SetChannel("DensityVariationRange", 0f);
        csound.SetChannel("DensityVariationRate", 4f);
        csound.SetChannel("PhaseVariation", 0f);

        //FILTER
        csound.SetChannel("FilterNoteTrack", 1);
        csound.SetChannel("FilterSelection", 1);
        csound.SetChannel("FilterFreq", 0.2f);
        csound.SetChannel("FilterRange", 0.0001f);
        csound.SetChannel("FilterReson", 2.1f);
        csound.SetChannel("FilterBW", 0);
        csound.SetChannel("FilterAttack", 1f);
        csound.SetChannel("FilterDecay", 1f);
        csound.SetChannel("FilterSustain", 1f);
        csound.SetChannel("FilterRelease", 6f);

        //LFOs
        csound.SetChannel("LfoFilterFreq", 0f);
        csound.SetChannel("LfoFilterRange", 0f);
        csound.SetChannel("LfoModAmpFreq", 0f);
        csound.SetChannel("LfoModAmpRange", 0f);

        //MODULATION
        csound.SetChannel("RMFreq", 1200f);
        csound.SetChannel("RMAmp", 0f);
        csound.SetChannel("FMFreq", 4700f);
        csound.SetChannel("FMAmp", 0f);

        //GLOBALS
        csound.SetChannel("GlobalVolume", 0.17f);
        csound.SetChannel("GlobalPan", 0.5f);
        csound.SetChannel("GlobalTuning", 0f);

        //AMP ENVELOPE
        csound.SetChannel("AmpEnvelopeToggle", 0);
        csound.SetChannel("AmpAttack", 1f);
        csound.SetChannel("AmpDecay", 0.1f);
        csound.SetChannel("AmpSustain", 1f);
        csound.SetChannel("AmpRelease", 6f);

        //REVERB
        csound.SetChannel("ReverbBypass", 1);
        csound.SetChannel("ReverbSend", 1);
        csound.SetChannel("ReverbMix", 0.3f);
        csound.SetChannel("ReverbSize", 0.9f);

        //DELAY
        csound.SetChannel("DelayBypass", 0);
        csound.SetChannel("DelaySend", 1);
        csound.SetChannel("DelayMix", 1);
        csound.SetChannel("DelayTimeLeft", 0.37f);
        csound.SetChannel("DelayTimeRight", 0.7f);
        csound.SetChannel("DelayFeedback", 0.7f);
    }
}
