var app = getApp();
Page({

  /**
   * 页面的初始数据
   */
  data: {
    expressNum :null,
    expressInfos : []
  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function (options) {
    
  },

  /**
   * 生命周期函数--监听页面初次渲染完成
   */
  onReady: function () {
    
  },

  /**
   * 生命周期函数--监听页面显示
   */
  onShow: function () {
    
  },

  /**
   * 生命周期函数--监听页面隐藏
   */
  onHide: function () {
    
  },

  /**
   * 生命周期函数--监听页面卸载
   */
  onUnload: function () {
    
  },

  /**
   * 页面相关事件处理函数--监听用户下拉动作
   */
  onPullDownRefresh: function () {
    
  },

  /**
   * 页面上拉触底事件的处理函数
   */
  onReachBottom: function () {
    
  },

  /**
   * 用户点击右上角分享
   */
  onShareAppMessage: function () {
    
  },
  input:function(e){
    this.setData({
      expressNum: e.detail.value
    });
    //console.info(e.detail.value);
  },
  btnSearch : function(){
    console.info(this.data.expressNum);
    var self = this;
    app.SearchExpress(this.data.expressNum,function(r){
      //console.info(r);
      self.setData({
        expressInfos : [{
            context:'A',
            time:'2018-08-03'
        }, {
            context: 'B',
            time: '2018-08-03'
          }, {
            context: 'C',
            time: '2018-08-03'
          }, {
            context: 'D',
            time: '2018-08-03'
          }, {
            context: 'E',
            time: '2018-08-03'
          }, {
            context: 'F',
            time: '2018-08-03'
          }, {
            context: 'A',
            time: '2018-08-03'
          }, {
            context: 'B',
            time: '2018-08-03'
          }, {
            context: 'C',
            time: '2018-08-03'
          }, {
            context: 'D',
            time: '2018-08-03'
          }, {
            context: 'E',
            time: '2018-08-03'
          }, {
            context: 'F',
            time: '2018-08-03'
          }, {
            context: 'A',
            time: '2018-08-03'
          }, {
            context: 'B',
            time: '2018-08-03'
          }, {
            context: 'C',
            time: '2018-08-03'
          }, {
            context: 'D',
            time: '2018-08-03'
          }, {
            context: 'E',
            time: '2018-08-03'
          }, {
            context: 'F',
            time: '2018-08-03'
          }]
      });
    });
  }
})