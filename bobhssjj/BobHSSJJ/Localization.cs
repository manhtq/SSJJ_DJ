using System;
using System.Collections.Generic;

namespace Veh
{
    internal static class L
    {
        static readonly Dictionary<string, Dictionary<string, string>> languageToStrings = new Dictionary<string, Dictionary<string, string>>(StringComparer.OrdinalIgnoreCase)
        {
            {
                "zh-CN", new Dictionary<string, string>
                {
                    { "app.title", "迪迦 - 破解版" },
                    { "menu.esp", "透视" },
                    { "menu.aimbot", "自动瞄准" },
                    { "menu.visual", "视觉" },
                    { "menu.misc", "杂项" },
                    { "menu.config", "配置文件" },
                    { "menu.fps", "FPS: {0}" },

                    { "visual.title", "视觉设置" },
                    { "visual.noTeammateName", "不显示队友名字(游戏内)" },
                    { "visual.crosshair", "全屏准星" },
                    { "visual.noTeammateRender", "不渲染队友模型" },
                    { "visual.noHpBar", "不显示血条(游戏内)" },
                    { "visual.noVisualRecoil", "无视觉后坐力" },

                    { "esp.title", "玩家透视" },
                    { "esp.showTeammate", "透视队友" },
                    { "esp.showEnemy", "透视敌人" },
                    { "esp.showName", "显示名字" },
                    { "esp.showTraceline", "追踪线条" },
                    { "esp.showBone", "骨骼透视" },
                    { "esp.showHealth", "血量透视" },
                    { "esp.showDistance", "距离透视" },
                    { "esp.colors.title", "颜色设置:" },
                    { "esp.colors.enemy", "敌人颜色:" },
                    { "esp.colors.team", "队友颜色:" },
                    { "esp.colors.traceline", "追踪线条颜色:" },
                    { "esp.thickness.title", "粗细设置:" },
                    { "esp.thickness.box", "方框粗细" },
                    { "esp.thickness.traceline", "追踪线条粗细" },
                    { "esp.thickness.bone", "骨骼粗细" },

                    { "aim.title", "自动瞄准" },
                    { "aim.enable", "启动标准自瞄" },
                    { "aim.team", "是否瞄准队友" },
                    { "aim.method", "瞄准方式:" },
                    { "aim.method.mouse", "鼠标API自瞄" },
                    { "aim.method.camera", "内部摄像机自瞄" },
                    { "aim.pos", "瞄准位置:" },
                    { "aim.pos.head", "头部" },
                    { "aim.pos.neck", "脖子" },
                    { "aim.pos.spine.up", "上脊柱" },
                    { "aim.pos.spine.down", "下脊柱" },
                    { "aim.key.title", "自瞄按键:" },
                    { "aim.key.e", "E键" },
                    { "aim.key.ctrl", "左Ctrl键" },
                    { "aim.key.mouse.left", "鼠标左键" },
                    { "aim.key.mouse.right", "鼠标右键" },
                    { "aim.range.title", "自瞄范围:" },
                    { "aim.range.unit", "半径: %.0f" },
                    { "aim.speed.title", "自瞄速度:" },
                    { "aim.smooth", "自瞄平滑度" },
                    { "aim.maxAngle", "摄像机自瞄最大角度" },
                    { "aim.maxAngle.unit", "最大角度: %.2f" },
                    { "aim.norecoil", "无后坐力(瞄准时)" },
                    { "aim.brutal", "暴力自瞄:" },
                    { "aim.silent", "启动子弹追踪" },
                    { "aim.onkey", "手动开枪(按中键开枪)[P]" },
                    { "aim.psilent", "完美静默(网络通畅时使用)" },
                    { "aim.hitscan", "全身扫描(卡顿)[鼠标上侧键-按住临时切换]" },
                    { "aim.body", "仅攻击身体" },

                    { "misc.title", "杂项设置" },
                    { "misc.bhop", "连跳" },
                    { "misc.antiaim.toggle", "反自瞄启动[Home]" },
                    { "misc.antiaim.x", "反自瞄X轴类型:" },
                    { "misc.antiaim.x.fakeup", "假抬头[Num7]" },
                    { "misc.antiaim.x.fakedown", "假低头[Num9]" },
                    { "misc.antiaim.x.up", "抬头[Num8]" },
                    { "misc.antiaim.x.down", "低头[Num2]" },
                    { "misc.antiaim.x.zero", "平视[Num5]" },
                    { "misc.antiaim.y", "反自瞄Y轴类型:" },
                    { "misc.antiaim.y.manual", "手动" },
                    { "misc.antiaim.y.spin", "旋转" },
                    { "misc.antiaim.y.jitter", "抖动" },
                    { "misc.antiaim.y.angle", "Y轴角度" },
                    { "misc.antiaim.spin.speed", "旋转速度" },
                    { "misc.antiaim.jitter.min", "最小抖动角度" },
                    { "misc.antiaim.jitter.max", "最大抖动角度" },
                    { "misc.hotkeys", "键盘快捷键: Z=左 X=背身 C=右" },
                    { "misc.fakelag.toggle", "假延迟[Num0]" },
                    { "misc.fakelag.count.title", "假延迟延迟数:" },
                    { "misc.fakelag.count", "假延迟" },
                    { "misc.fakelag.unit", "延迟: %.0fTick" },
                    { "misc.weapon", "武器:" },
                    { "misc.weapon.accuracy", "射击精准度" },
                    { "misc.weapon.accuracy.tip", "*过高会不开枪" },

                    { "config.title", "配置管理" },
                    { "config.save", "保存配置" },
                    { "config.load", "载入配置" },
                    { "config.missing", "配置文件不存在!" },
                    { "config.exists", "配置文件存在!" },
                    { "config.save.fail", "保存失败,异常信息:" },
                    { "config.save.ok", "保存成功!" },
                    { "config.load.fail", "载入失败,异常信息:" },
                    { "config.load.ok", "载入成功" },
                    { "config.load.missing", "配置文件不存在,载入失败!" },
                    { "config.language", "语言(Language)" },
                }
            },
            {
                "vi-VN", new Dictionary<string, string>
                {
                    { "app.title", "Dijia - bản mở khóa" },
                    { "menu.esp", "ESP" },
                    { "menu.aimbot", "Tự động ngắm" },
                    { "menu.visual", "Hiển thị" },
                    { "menu.misc", "Khác" },
                    { "menu.config", "Cấu hình" },
                    { "menu.fps", "FPS: {0}" },

                    { "visual.title", "Cài đặt hiển thị" },
                    { "visual.noTeammateName", "Ẩn tên đồng đội (ingame)" },
                    { "visual.crosshair", "Tâm chữ thập toàn màn" },
                    { "visual.noTeammateRender", "Không vẽ model đồng đội" },
                    { "visual.noHpBar", "Ẩn thanh máu (ingame)" },
                    { "visual.noVisualRecoil", "Không giật hình ảnh" },

                    { "esp.title", "ESP người chơi" },
                    { "esp.showTeammate", "Hiện đồng đội" },
                    { "esp.showEnemy", "Hiện địch" },
                    { "esp.showName", "Hiện tên" },
                    { "esp.showTraceline", "Đường truy vết" },
                    { "esp.showBone", "Hiện khung xương" },
                    { "esp.showHealth", "Hiện máu" },
                    { "esp.showDistance", "Hiện khoảng cách" },
                    { "esp.colors.title", "Màu sắc:" },
                    { "esp.colors.enemy", "Màu kẻ địch:" },
                    { "esp.colors.team", "Màu đồng đội:" },
                    { "esp.colors.traceline", "Màu đường truy vết:" },
                    { "esp.thickness.title", "Độ dày:" },
                    { "esp.thickness.box", "Độ dày khung" },
                    { "esp.thickness.traceline", "Độ dày đường" },
                    { "esp.thickness.bone", "Độ dày xương" },

                    { "aim.title", "Tự động ngắm" },
                    { "aim.enable", "Bật ngắm tiêu chuẩn" },
                    { "aim.team", "Ngắm vào đồng đội" },
                    { "aim.method", "Phương thức:" },
                    { "aim.method.mouse", "API chuột" },
                    { "aim.method.camera", "Camera nội bộ" },
                    { "aim.pos", "Vị trí ngắm:" },
                    { "aim.pos.head", "Đầu" },
                    { "aim.pos.neck", "Cổ" },
                    { "aim.pos.spine.up", "Đốt sống trên" },
                    { "aim.pos.spine.down", "Đốt sống dưới" },
                    { "aim.key.title", "Phím ngắm:" },
                    { "aim.key.e", "Phím E" },
                    { "aim.key.ctrl", "Ctrl trái" },
                    { "aim.key.mouse.left", "Chuột trái" },
                    { "aim.key.mouse.right", "Chuột phải" },
                    { "aim.range.title", "Phạm vi ngắm:" },
                    { "aim.range.unit", "Bán kính: %.0f" },
                    { "aim.speed.title", "Tốc độ ngắm:" },
                    { "aim.smooth", "Độ mượt ngắm" },
                    { "aim.maxAngle", "Góc tối đa (camera)" },
                    { "aim.maxAngle.unit", "Góc: %.2f" },
                    { "aim.norecoil", "Không giật (khi ngắm)" },
                    { "aim.brutal", "Nâng cao:" },
                    { "aim.silent", "Kích hoạt đạn truy đuổi" },
                    { "aim.onkey", "Bắn thủ công (giữa chuột)[P]" },
                    { "aim.psilent", "Silent hoàn hảo (mạng tốt)" },
                    { "aim.hitscan", "Quét toàn thân (lag)" },
                    { "aim.body", "Chỉ bắn vào thân" },

                    { "misc.title", "Cài đặt khác" },
                    { "misc.bhop", "Nhảy liên tục" },
                    { "misc.antiaim.toggle", "Bật chống aim [Home]" },
                    { "misc.antiaim.x", "Kiểu chống aim trục X:" },
                    { "misc.antiaim.x.fakeup", "Giả ngẩng [Num7]" },
                    { "misc.antiaim.x.fakedown", "Giả cúi [Num9]" },
                    { "misc.antiaim.x.up", "Ngẩng [Num8]" },
                    { "misc.antiaim.x.down", "Cúi [Num2]" },
                    { "misc.antiaim.x.zero", "Nhìn thẳng [Num5]" },
                    { "misc.antiaim.y", "Kiểu chống aim trục Y:" },
                    { "misc.antiaim.y.manual", "Thủ công" },
                    { "misc.antiaim.y.spin", "Xoay" },
                    { "misc.antiaim.y.jitter", "Rung" },
                    { "misc.antiaim.y.angle", "Góc Y" },
                    { "misc.antiaim.spin.speed", "Tốc độ xoay" },
                    { "misc.antiaim.jitter.min", "Góc rung tối thiểu" },
                    { "misc.antiaim.jitter.max", "Góc rung tối đa" },
                    { "misc.hotkeys", "Phím tắt: Z=trái X=xoay lưng C=phải" },
                    { "misc.fakelag.toggle", "Giả ping [Num0]" },
                    { "misc.fakelag.count.title", "Số khung giả ping:" },
                    { "misc.fakelag.count", "Giả ping" },
                    { "misc.fakelag.unit", "Trễ: %.0fTick" },
                    { "misc.weapon", "Vũ khí:" },
                    { "misc.weapon.accuracy", "Độ chính xác bắn" },
                    { "misc.weapon.accuracy.tip", "*Quá cao có thể không bắn" },

                    { "config.title", "Quản lý cấu hình" },
                    { "config.save", "Lưu cấu hình" },
                    { "config.load", "Tải cấu hình" },
                    { "config.missing", "Không tìm thấy cấu hình!" },
                    { "config.exists", "Đã có cấu hình!" },
                    { "config.save.fail", "Lưu thất bại, lỗi:" },
                    { "config.save.ok", "Lưu thành công!" },
                    { "config.load.fail", "Tải thất bại, lỗi:" },
                    { "config.load.ok", "Tải thành công" },
                    { "config.load.missing", "Không có cấu hình, tải thất bại!" },
                    { "config.language", "Ngôn ngữ (Language)" },
                }
            }
        };

        static string currentLanguage = "vi-VN";

        public static void SetLanguage(string lang)
        {
            if (string.IsNullOrEmpty(lang)) return;
            if (languageToStrings.ContainsKey(lang))
            {
                currentLanguage = lang;
            }
        }

        public static string GetLanguage()
        {
            return currentLanguage;
        }

        public static string T(string key)
        {
            Dictionary<string, string> strings;
            if (!languageToStrings.TryGetValue(currentLanguage, out strings))
            {
                strings = languageToStrings["zh-CN"];
            }
            string value;
            if (strings.TryGetValue(key, out value))
            {
                return value;
            }
            if (languageToStrings["zh-CN"].TryGetValue(key, out value))
            {
                return value;
            }
            return key;
        }
    }
}

