/**
 * Created by luo on 2019/5/12.
 */

$(function(){
    function f(element,r,g,b){
        element.css('color','rgb('+r+','+g+','+b+')');
    };
    function l(element,i){
        element.css('opacity',i);
    }

    var el = $("#test");
    var red = 0,green = 0,blue=0,i=1;
    var s,o,u,a,c;
    c = $.YBslider({
        blockClick:function(){
            a = 0;
        },
        valueChange:function(i,s,o){
            o === 0 && el.css('fontSize',i);
            o > 0 && (o === 1 ?t=i:o===2?n=i:o===3&&(r=i),f());
        }
    });

    var g=$.YBslider(
        {
            slidMain:"<span class='s-m2' style='display:none' />",
            slidMainIn:"<span class='s-m-i2' />",
            slidBar:"<i class='s-bar2' />",
            slidBarBg:"<i class='s-b-b2' />",
            slidBlock:"<a class='s-btn2' href='javascript:;' />",
            slidValueShowBox:"<span class='s-v-b2' />",
            slidBox:"#ui_test_2",
            slidWidth:200,
            setValue:[0,1,.5],
            showValue:1,
            editValue:1,
            valueFloat:0,
            valueSuf:"联动左侧测试区域透明度",
            showRange:true
        });
    g.YBslider[0].valueChange(function(e,t){
        //m.YBslider[0].keepMove(t)
    });
    console.info(g);
})