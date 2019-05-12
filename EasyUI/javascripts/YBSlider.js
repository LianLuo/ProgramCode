(function ($) {
    function YBslider(opts) {
        var publicObj = {
            index: 0,
            YBslider: []
        };
        var mainDoc = $(document);
        var oBox = $(opts.slidBox);
        oBox.length === 0 && (oBox = $(document.body));
        $.each(oBox, function () {
            var _fnSlidMain = fnSlidMain(opts, this, publicObj.index);
            publicObj.YBslider[publicObj.index] = {
                keepMove: _fnSlidMain.keepMove,
                valueChange: _fnSlidMain.valueChange,
                percent: _fnSlidMain.percent
            };
            publicObj.index += 1;
        });


        function fnSlidMain(opts, obj, _index) {
            var _opt = $.extend({}, YBslider.config, opts);
            var self = obj;
            var oBoxCur, oInp, oValSuf, oMain, oMainIn, oBar;
            var oBarBg, oBlock, oLeft, oRight, oValueShowBox;
            oBoxCur = $(self);
            oValueShowBox = $(_opt.slidValueShowBox);
            //debugger;
            oInp = $("input[setValue]", self);
            if (oInp.length === 0) {
                oInp = $("<input class='slider-inp' type='hidden' />")
            } else {
                oInp.attr('type', 'hidden');
            }

            oValSuf = $(_opt.slidValueSuf);
            oMain = $(_opt.slidMain);
            oMainIn = $(_opt.slidMainIn);
            oBar = $(_opt.slidBar);
            oBarBg = $(_opt.slidBarBg);
            oBlock = $(_opt.slidBlock);
            var arrInpValueMinMax;

            if (oInp.length === 1 && (/\,/).test((arrInpValueMinMax = oInp.attr('setValue')))) {
                arrInpValueMinMax = arrInpValueMinMax.split(',');
            } else {
                arrInpValueMinMax = [];
            }

            _opt.valueSuf = oInp.attr('setValueSuf') || _opt.valueSuf;
            _opt.valueFloat = oInp.attr('setValueFloat') || _opt.valueFloat;
            arrInpValueMinMax.length >= 2 && (_opt.setValue = arrInpValueMinMax);
            _opt.valueLeft = parseFloat(_opt.setValue[0]) || 0;
            _opt.valueRight = parseFloat(_opt.setValue[1]) || 0;
            _opt.valueInit = parseFloat(_opt.setValue[2]) || 0;

            oMain.append(oMainIn.append(oBarBg, oBar, oBlock));
            if (_opt.showRange) {
                oLeft = $(_opt.slidLeft);
                oRight = $(_opt.slidRight);
                oMain.prepend(oLeft.html(_opt.valueLeft));
                oMain.append(oRight.html(_opt.valueRight));
            }

            var oTimer, numBlockW, numBlockW_h, numBlockH_h;
            var numMainInWidth, numIsAbleWidth, numMin, numMax;
            var numMouseInX = 0, numBlockLeftOld = 0, boolKeepMove = 1;
            if (_opt.valueLeft > _opt.valueRight) {
                numMin = _opt.valueRight;
                numMax = _opt.valueLeft;
            } else {
                numMin = _opt.valueLeft;
                numMax = _opt.valueRight;
            }
            oValueShowBox.append(oInp);

            if (_opt.showValue) {
                oValueShowBox.append(oValSuf);
                if (_opt.editValue) {
                    oInp.attr('type', 'text');
                }
            }

            oMainIn.width(_opt.slidWidth);
            oBoxCur.append(oValueShowBox);
            oBoxCur.prepend(oMain);
            oMain.show();

            numBlockW = oBlock.width();
            numBlockW_h = Math.floor(numBlockW / 2);
            numBlockH_h = Math.floor(oBlock.height() / 2);

            oBlock.css('marginTop', -numBlockH_h);
            numIsAbleWidth = _opt.slidWidth - numBlockW;
            valToMove(_opt.valueInit, null, 1);
            if (_opt.showValue && _opt.editValue) {
                oInp.change(function () {
                    document.title += 1;
                    oTimer && clearTimeout(oTimer);
                    oTimer = setTimeout(function () {
                        var v = oInp.val();
                        if ((/^[\-\+]?\d+(\.\d+)?$/).test(v)) {
                            v = Math.floor(parseFloat(v));
                            valToMove(v, null, 1);
                        }
                    }, 30);
                });
            }

            oBlock.mousedown(function (e) {
                numMouseInX = e.clientX - numBlockLeftOld;
                mainDoc.bind('mousemove', fnMouseMove).bind('mouseup', fnMouseUp);
                return false;
            }).click(function () {
                _opt.blockClick && _opt.blockClick();
            });

            var _optReset = {};

            _optReset.keepMove = function (v) {
                v = fnRangeValue([0, 1], v);
                fnInputVal(v, function () {
                    oBlock.stop();
                    oBar.stop();
                    move(v, 0, boolKeepMove);
                    boolKeepMove = 0;
                });
            };

            _optReset.valueChange = function (fn) {
                _opt.valueChange = fn;
            };

            _optReset.percent = function (fn) {
                return _opt.percent;
            };


            function fnMouseMove(e) {
                moveToVal(e.clientX - numMouseInX);
            }

            function fnMouseUp(e) {
                mainDoc.unbind('mousemove', fnMouseMove).unbind('mouseup', fnMouseUp);
            }

            function move(val, fn, animate, c) {
                val *= numIsAbleWidth;
                numBlockLeftOld = val;
                if (animate) {
                    oBlock.animate({
                        'left': val + 'px'
                    });
                    oBar.animate({
                        'width': val + numBlockW_h + 'px'
                    }, function () {
                        fn && fn();
                    });
                    return;
                } else {
                    oBlock.css('left', val + 'px');
                    oBar.css('width', val + numBlockW_h + 'px');
                }
                fn && fn();
            }

            function fnInputVal(val, fn) {
                var percent;
                val = _opt.valueLeft < _opt.valueRight ? val : 1 - val;
                percent = val;
                val = val * (numMax - numMin) + numMin;
                val = !_opt.valueFloat ? Math.round(val) : val.toFixed(_opt.valueFloat || 0);
                numInpValue = val;
                oInp.val(val);
                oValSuf && oValSuf.html((_opt.editValue ? "" : val) + _opt.valueSuf);
                oBlock.attr('title', val);
                _opt.valueChange && _opt.valueChange(numInpValue, percent, _index);
                _opt.percent = percent;
                fn && fn();
            }

            function fnRangeValue(range, val) {
                return val <= range[0] ? range[0] : val >= range[1] ? range[1] : val;
            }

            function valToMove(v, fn, bool) {
                v = fnRangeValue([numMin, numMax], v);
                _opt.valueLeft > _opt.valueRight && (v = numMax + numMin - v);
                v = (v - numMin) / (numMax - numMin);
                fnInputVal(v, function () {
                    move(v || 0, fn, bool);
                });
            };

            function moveToVal(v,fn){
                v = fnRangeValue([0, numIsAbleWidth], Math.floor(v)) / numIsAbleWidth;
                move(v,function() {
                        fnInputVal(v || 0, fn)
                    });
            }

            return _optReset;
        }

        return publicObj;
    }

    YBslider.config = {
        slidMain: '',// 可选，滑动条主要部分Box[HTML string]
        slidMainIn: '',// 可选，Box[HTML string],包裹slidBarBg,slidBar,slidBlock
        slidBar: '',// 可选，滑条已选择部分Box[HTML string]
        slidBarBg: '',// 可选，滑条未选择部分Box[HTML string]
        slidBlock: '',// 可选，滑块Box[HTML string]
        slidLeft: '',// 可选，用以显示最小值的Box[HTML string]
        slidRight: '',// 可选，用以显示最大值的Box[HTML string]
        slidValueShowBox: '',// 可选，用以修饰展示值得Box[HTML string]
        slidValueSuf: '',
        slidWidth: 380,// 可选，[number]default value 180
        valueLeft: 0,// 可选，滑动器左端值
        valueRight: 0,// 可选，滑动器右端值
        valueInit: 0,// 可选，滑动器初始值
        valueFloat: 0,// 可选，滑动器取值多少小数点,默认取整
        showValue: false,// 可选，是否显示取值
        valueSuf: '',// 单位
        editValue: false,//可选，是否可以‘通过输入设置’
        showRange: true// 可选，是否在滑动器两端显示取值范围
    };

    $.extend({
        'YBslider': YBslider
    })
})(jQuery) && jQuery;