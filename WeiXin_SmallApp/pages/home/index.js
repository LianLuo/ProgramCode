Page({

  /**
   * 页面的初始数据
   */
  data: {
    text:'Hello world.',
    btnText : 'Login',
    isShow : false,
    templateSrc:'../templates/_layout'
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
  btnClick:function(){
    var isshow = this.data.isShow;
    this.setData({ 
      btnText: 'the text has change.',
      isShow: !isshow
    });
   // console.info('you click btnText.');

  },
  clickView1 : function(){
    console.info('clickView1');
  },
  clickView2:function(){
    console.info('clickView2');
  },
  clickView3:function(){
    console.info("clickview3");
  }
})