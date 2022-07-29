<CsoundSynthesizer>
<CsOptions>
</CsOptions>
<CsInstruments>
sr             =         44100
kr             =         4410
ksmps          =         10
nchnls         =         2

garvb          init      0

               ctrlinit  1, 21,120, 22,64, 23,64, 24,64 

               instr     1      
ip5            cpsmidi
ifreq          =         ip5
ip3            midic7    24, 1, 8
ip6            midic7    21, 0, 3000
kp7            midic7    22, 0, 1
ip8            midic7    23, 0, 100

k3             expseg    1, ip3 * .5, 30 ,ip3 * .5, 2            
k4             expseg    10, ip3 *.7, ip8, ip3 *.3, 6         
k8             linen     ip6, ip3 * .333, ip3, ip3 * .333
k13            line      0, ip3, -1

k14            randh     k3, k4, .5
a1             oscil     k8, ifreq + (ip5 * .05) + k14 + k13, 1, .1

k1             expseg    1, ip3 * .8, 6, ip3 *.2, 1
k6             linseg    .4, ip3 * .9, ip8 * .96, ip3 * .1, 0
k7             linseg    8, ip3 * .2, 10, ip3 * .76, 2

kenv2          expseg    .001, ip3 * .4, ip6 * .99, ip3 * .6, .0001
k15            randh     k6, k7
a2             buzz      kenv2, ifreq + (ip5 * .009) + k15 + k13, k1, 1, .2

kenv1          linen     ip6, ip3 * .25, ip3, ip3 * .4
k16            randh     k4 * 1.4, k7 * 2.1, .2
a3             oscil     kenv1, ifreq + (ip5 * .1) + k16 + k13, 16, .3

kmgate         linsegr   0, .1, 1, 1, 0

amix           =         (a1 + a2 + a3)*kmgate
               outs      (a1 + a3)*kmgate, (a2 + a3)*kmgate
garvb          =         garvb + (amix * kp7)
               endin

               instr     99                                 ; p4 = PANRATE
k1             oscil     .5, p4, 1
k2             =         .5 + k1
k3             =         1 - k2
asig           reverb    garvb, 2.1
               outs      asig * k2, (asig * k3) * (-1)
garvb          =         0
               endin



</CsInstruments>
<CsScore>
;==============================================================================;
;==============================================================================;
;                            == TRAPPED IN CONVERT ==                          ;
;                                Richard Boulanger                             ;
;==============================================================================; 
;==============================================================================; 
; i1:  p6=amp,p7=vibrat,p8=glisdeltime (default < 1),p9=frqdrop                ;
; i2:  p6=amp,p7=rvbsnd,p8=lfofrq,p9=num of harmonics,p10=sweeprate            ;
; i3:  p6=amp,p7=rvbsnd,p8=rndfrq                                              ;
; i4:  p6=amp,p7=fltrswp:strtval,p8=fltrswp:endval,p9=bdwth,p10=rvbsnd         ;
; i5:  p6=amp,p7=rvbatn,p8=pan:1.0,p9=carfrq,p10=modfrq,p11=modndx,p12=rndfrq  ;
; i6:  p5=swpfrq:strt,p6=swpfrq:end,p7=bndwth,p8=rvbsnd,p9=amp                 ;
; i7:  p4=amp,p5=frq,p6=strtphse,p7=endphse,p8=ctrlamp(.1-1),p9=ctrlfnc        ;
;             p10=audfnc(f2,f3,f14,p11=rvbsnd                                  ;
; i8:  p4=amp,p5=swpstrt,p6=swpend,p7=bndwt,p8=rnd1:cps,p9=rnd2:cps,p10=rvbsnd ;
; i9:  p4=delsnd,p5=frq,p6=amp,p7=rvbsnd,p8=rndamp,p9=rndfrq                   ;
; i10: p4=0,p5=frq,p6=amp,p7=rvbsnd,p8=rndamp,p9=rndfrq                        ;
; i11: p4=delsnd,p5=frq,p6=amp,p7=rvbsnd                                       ;
; i12: p6=amp,p7=swpstrt,p8=swppeak,p9=bndwth,p10=rvbsnd                       ;
; i13: p6=amp,p7=vibrat,p8=dropfrq                                             ;
; i98: p2=strt,p3=dur                                                          ;
; i99: p4=pancps                                                               ;
;========================= FUNCTIONS ==========================================;
f1   0  8192  10   1
/*
f2   0  512   10   10  8   0   6   0   4   0   1
f3   0  512   10   10  0   5   5   0   4   3   0   1
f4   0  2048  10   10  0   9   0   0   8   0   7   0  4  0  2  0  1
f5   0  2048  10   5   3   2   1   0
f6   0  2048  10   8   10  7   4   3   1
f7   0  2048  10   7   9   11  4   2   0   1   1
f8   0  2048  10   0   0   0   0   7   0   0   0   0  2  0  0  0  1  1
f9   0  2048  10   10  9   8   7   6   5   4   3   2  1
f10  0  2048  10   10  0   9   0   8   0   7   0   6  0  5
f11  0  2048  10   10  10  9   0   0   0   3   2   0  0  1
f12  0  2048  10   10  0   0   0   5   0   0   0   0  0  3
f13  0  2048  10   10  0   0   0   0   3   1
f14  0  512   9    1   3   0   3   1   0   9  .333   180
f15  0  8192  9    1   1   90 
*/
f16  0  2048  9    1   3   0   3   1   0   6   1   0

/*
f17  0  9     5   .1   8   1
f18  0  17    5   .1   10  1   6  .4
f19  0  16    2    1   7   10  7   6   5   4   2   1   1  1  1  1  1  1  1
f20  0  16   -2    0   30  40  45  50  40  30  20  10  5  4  3  2  1  0  0  0
f21  0  16   -2    0   20  15  10  9   8   7   6   5   4  3  2  1  0  0
f22  0  9    -2   .001 .004 .007 .003 .002 .005 .009 .006
*/

f0   60

i99  0   60     12
e
</CsScore>
</CsoundSynthesizer>
<bsbPanel>
 <label>Widgets</label>
 <objectName/>
 <x>0</x>
 <y>0</y>
 <width>0</width>
 <height>0</height>
 <visible>true</visible>
 <uuid/>
 <bgcolor mode="nobackground">
  <r>255</r>
  <g>255</g>
  <b>255</b>
 </bgcolor>
</bsbPanel>
<bsbPresets>
</bsbPresets>
