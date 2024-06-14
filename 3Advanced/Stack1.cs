using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq.Expressions;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;

namespace _3Advanced
{
    internal class Stack1
    {
        /// <summary>
        /// Given an expression string A, examine whether the pairs and the orders of “{“,”}”, ”(“,”)”, ”[“,”]” are correct in A.
        /// Refer to the examples for more clarity.
        /// Problem Constraints
        /// 1 <= |A| <= 100
        /// </summary>
        public static void BalancedParanthesis()
        {
            string A = "{([])}";
            //A = "(){";
            //A = "()[]";

            Stack st = new Stack();
            for (int i = 0; i < A.Length; i++)
            {
                char c = A[i];
                char ic ;
                if (c == '{' || c == '(' || c == '[')
                {
                    st.Push(c);
                }
                else if (c == '}')
                {
                    ic = (char)st.Pop();
                    if (ic != '{')
                    {
                        Console.WriteLine(0);
                        return;
                    }
                }
                else if (c == ')')
                {
                    ic = (char)st.Pop();
                    if (ic != '(')
                    {
                        Console.WriteLine(0);
                        return;
                    }
                }
                else if (c == ']')
                {
                    ic = (char)st.Pop();
                    if (ic != '[')
                    {
                        Console.WriteLine(0);
                        return;
                    }
                }
            }

            Console.WriteLine(st.IsEmpty() ? 1 : 0);

        }
        /// <summary>
        /// You have a string, denoted as A.
        /// To transform the string, you should perform the following operation repeatedly:
        /// Identify the first occurrence of consecutive identical pairs of characters within the string.
        /// Remove this pair of identical characters from the string.
        /// Repeat steps 1 and 2 until there are no more consecutive identical pairs of characters.
        /// The final result will be the transformed string.
        /// Problem Constraints
        /// 1 <= |A| <= 100000
        /// </summary>
        public static void DoubleCharacterTrouble()
        {
            string A = "abccbc";//ac
            //A = "ab";//ab
            //A = "cddfeffe";//cf
            //A = "hdltwytsrwwgguhctuadozfkwnufgioomzjizdcqzayhuflpcmssnzckoypvidluewedzivbitkcawsckmwxmyhaywxhbidffkkgsfjbauddqxfakczwchydfwkhgnonxzwsghtjbymtwrvgvveaeedlcpsjcjyckuuqcpzfnlbjfyrcvvezahlewfnbqofakbroqsufexplvipreusgbfkanaddoieajxpbplgvivgfgywksrstwevjeynuitvrqmsfxbbfyjkehjozcivynskrrzozsltixnpwoqbncnrjyilaqibdanxtmnveyooxbdtswwfylyjmgwozepehcbcqqxuqlknpoijkgqkuovgxsuwymafqeihuhdltoakelvqrlcnzxvwpsuoevvwzfftnjgizhufupvnazbbwwaooucupzrqhwmuhsegbynvpijpjmsgisuzpytezkxgjjcqdgzhemetxpkgbfokzijoievirsqadtsgztpgiubfjonntcxsmihvocffwvhzochqvxwdtxkelargeozqyinnmuuiqchgeqybpufiurnfreovvnovxdkjyfrqjaynsxoirvqlpdtikhgfwucvxnexsxnbzmqrjgzcesqtxjdhsjoqfrlfercyqsbretipzkrfchybsejknzcvqpawiewawzrascpsojxsqytleexreaowrotatraprusjwjdksdcldxwhcvagvpcpfxryptqgnkrltvxoazzdzxkbskhqzlhhjyfarxgfhzsdwqrwpszopjrjwybxkievgmvyjdftcxwznnvfhvvwgnhcnjazreuyqpycufvxctwsitxpqulxjubxdbwxitxykvcfazcesawavvpmqclzxmycoxzyqyyavbfvajctlavhwlvopgposotilugdtfdoilmiwodkozrmmoadussognxthfwakbpsmddltgvjhowtcyxyqrmyelrlrnobpfwdibqbhlkrbikfhjdzaqygdrsufiywnwbvxsygfixjrioatubumzcprwkyeiwrezmbrmjzvhkoryqksrgetjwmfgmkoiduhsxbegcbpmrgmhthbznwkjispwefehznzyqgfuhuizdvgwejvrfidpaslearnbhpazvfucbcdezkafvyzbgcsiweowvbycqyclfyqgctnefnjbnievkwdhcrfyvdcldgzierrhkelstwtjfzerxkaabgaylckpjlzpcswoyjgsgbdnahearfavnctyefppspfwhdlgnravtdivmovetxbizwheewvwnatvgedvxfqqiyoumjaihdqiazoeykclmvisbnnzsfrcffxspzcyduifwxjujlhvjsqkfflyldaqizkzbozglilhfwdqhmlsedfklqkwtmoeobdppfxcnilueoknbxihbntoddkzsadgbixtnuxaejwkxgxagfijubxyhjxzjchnkgiacfcgozsohpqnxaytevrlgqmssvhfbpffwhnnifdqwtfvugpybilkzzctujyxafcyprnxwqpukvqgbfgeprooqskkdkjfqnefereckuwupmcstiyjzpzrhjdnumsmbytfqxjcrfwiuaanizyjqaaxjdkfpftqdmxvkgxdnvmhvoxfpxofxofjrroiwkacwzxihxovsaeqqdvibmnaaujuoaekmfoigmtolhldjrvzvrjyfzaftmbhmguaniitwdjhkunvoixjbghgfhobtpkhxehmpsinxrxiokdcuanyjwgofupbmailgsyxmgljxitnuzrqbeokaxbgrshfurrblpazvlluvekrfbihgytivuopnxuhrnkcelebypyuvilblvitubcpysglsdujqflxsryqgwkcgydstnlpqpfqinbaqwljdygvqenwbaahafbtsnjlcqbmdfowdzfiylfopsmsuncusdonszaxrdjwiasnzxvzkapavcuppwkjcawuzwrsadokdhyegverwvtrxniomsyosukttelvjafojfspbyizubqrpagdvgtnafjvjwqsywghdbzezhdvjvpawxfrdygddrznorhmpqwtrvxscdqnyfnwcspfsykwpllfdussmoldllynoobovqnxleedcobuamzdhtxtjjzuwzkmpncmdpjounuydvsdisirnimztntpofbfsdrwvcmrrgpveiaoclfrttqmjkdzrgfklwigbuxsdpnjxoxbbesuxjiivnimtpyengnodmhiburakodnswhrhraeekqzzpgmxtbahiileznrprehnobwhdaonsnojtchofjypsjutwnjprsehtapwadltqbcmelajvyzpjviiitxbmcjheygfbtatvefbsiknilcsgmcogzqudbdizlpcfrvcxddplnetzgnhvpwdpozupccqqtsvkpzksczdrezqmmyjcwmtmlndqstgnldyackvejyvpxoekonokahynwbdoujchmcjomesxfqpcetosiceilcyidbyzlaizerqsyksdajfecwymycxmgvulwskjvulbmbwklonmxusbstntvmfehzpetcpqwaskbqwnejbdgvgyovrmiyqpzhvtlllkndurtrgzchekckjrgcdqbvfacbvqohadmuuilajqhoamalfioiyrfetjhrzxyzamwvujvezfuarwlwfbgfunlqwshwrhxsttpodmuerqekmsitvqzsdkicfpywwxqprhfwubanthaibkbwbcogpyiwniulgldzukvomveheepfotcrvsymrgigpduxqxwkhtbvqfdvjsaznerjzpxsxgyolsldrjnzcoutvzoeuqghxxswoqolyoajhnoyzbzbsuwnvmupdcxazpynfmafacqjqeirihsadrpbdlqinniodibkucqveggwnonvyivdzmeeaxnpkxepghcaluxsceopuekuohapwgtwdglqerhkzjmkdmcistxoxkjnrlcptvnxczpiqwsrggclugtmztbydmlwznmslzpnagxtdpmlxowsvsgulhvqvgmuwanhceweltzqkmbjcxbxriucrpsnxhhvhwcldaqqtrgfdhpggqfyazasqvhqcqllnqzsqpimiormvgsbzzzzzctrxajbtxognnyfeirnwlzrrtusswutynnxqwajvoricrqgzhtvuuomnkgigabgoqdgpfpkuitwzjeysavnulbkvhuckvkaoqgdvxnpfgnersemubbomeahnulxswxgodjjawzffolygrmcsntgrtqfqbekzcqnhbxkzyrgmdfvwtxphsvamlhepmoqqggxhfhidzprewoaporygnzuagyruoikuokdvrmysdrybgbqusrahqxiyvzvkjfgzrkulyuddmeeufwqxnsffppglqbxaidbapwlnqqqewuybtobghimwxujpvgpdmrfbpsrfjjkfgijzzkfgsternogkwyqirvmgodnzmxgsiprjbzrtuvmkltuirkqkieqyhdxwddonviywjpsdkenwzkgqwycedsekybidhxsehqaqhsvrzlpyvvrrutyxmcjmesrnrjrabtqimnbnytltoclkwlhkntytnpieazgdtwnhloukhfdykqiidssrnskahvgjummpkzyvpsfzalxmdhuhzmymekmnfuycgmtqlsmcmtbmeaykiurjiryodmblhbnnnggaaudnngzujaerwxcfqattpxewytlmctmcnrpbyrxhtdapcewshqlwpsunnhbpbouohlrheqqztqrvxnpefbcuvykiflagbwvjjoqofhnazgyyunebqgwlegwktysvupgdeytjhjljpjhjxmlnujbbrxnkvfhrvpwboqmxzxgohoaecnrwwsxprkbosjhnyeoouamvxsjgilkmyejwyilqvngnyocyusnosblrvwyeiksiodfnmsfhhnwhbygvqvlkwwdtvdzdosnevurhnyqwmogpmonejyqhxuasxaxnskspfjzukpsygynsmazxbpeajhujjrwddoskaremjzkpzxjmailbaqdjzxuiqrlthdejxkvglfxlfgxfrkiralcbkxjaqwvzcbjzoehzmektkjybuiswvvyfujhkgclieujubqtpueigpikjqegnzgsvpzhxdthjpqdqixfedplsxvenzmabsuyjvghzbqkqhohrnowsehmdeqtdcvgwqfgnlpomfzcoplgeccwgjilnzesdazaqegfrvufctjrkvxozbkhkssztxtxxsxpyfurcowejgxtduhcxtjhobihacgxwfmxkhooxlthtqaynkckdnurqebrghofpdcbmqqjdjsybtwqfadinxcebdvkmlrbqtdclvopegnhbmygmbrcatgdydpkqgohztllobcuirdjddssgjugeamcfbmxicgjvswltyfdqjpvohnvshbwjpyqrmobpummojykhfnzqcvflkadsdbdtzumoindczrtkrdsxqtnvqugbumtapytpsffaukfvbygtdastthokcxnyliyagtrzaybuiiskiyflyxhtexfiushhahkjbdidclykusweqbqqaxjfurprjwamekvhofkqqkamcxruajkbiwicnxvywwmcgjjwotmhgpvkomfoxrpfnzicxfbtbpvkzgipbvwhmssagzoeqglefvicbjxebuqaazpeuolgifgqewwxcibidjmevmlwgbyjappufacnikgohcljkotqagwxshvajtljkagqdifltlbcopnadhsfppchwzjfuvpfxvvafanaopcegqglzzroovxkvgqpdhwbetdjwrkkimooeuzdvstjoqwlzoccvzfzsjiqcuakhqannbtiumsidovecxizyqatzijddmpmcpzpsuamhuwmkrqorynronkpxwucijokaqcvkehtygfixxwqylioyugxqaaymqlogpjtttorzwbytzptkziitofkqhkeyvtgmebfxqywmbvhambklluebcqrjbyhytqlxrsxhrttsqdvcefppcwsemlnpjxocnbcetzomujhlmcpshhjldbprnfhwcxzrybxrclgwvnjjpzcyglklnzccgjykgzbgcbagmgdjtmtknxiviugxwjzcuandbqlgrlmgrprmekyrjhnsdvrzgtedvtgwjredfrlyicnmplgyuvsyskzzfdcaykykddniuyjecwtrhzscumaoybndhrdfdephherdeahhyaagbuixhkmflzjstoawspdzuxcyzmhyoigqcqnjazrnbaiwoisjzyivvnuwzdwnlcfqsvbuusixustjcosbmcxjptfqwegkgnczidvfyfcsxydzmxdaacjrvqktusfdfhconztnfxhcxlejkjlklueinodjijmnsqdhqwuvwcztpdfzmqkxlqhagljouwdmmhucfqxbszxjccjrsvoflyftjpjfnmtzvpebgdeacbkhdtywqodbmlwvafapruqnjuqrauscwejbzhzpwdskoogqtifmexbqsrhsobwkhilgrlvnqpaefgwaqdnvaqlukumyyliftvmkijaabaggichyfwvimicwdrudceivawhkijljjrrtwysbupljyofdfcghioeinnvvxiggzxavyuzujkdjalmfnsmvjsgygdvdlblmaniyjjtvvyewjtbynqwykewqjrvuujgxyqvibqfxpjvaeybsoxqbdptmgpidaoayhxgkqnjfxehddivthoukdoylfgofxodgomqezalyescjdzdmnxzqlxcqgqvdhbjvpbzqbmpigtrjsuwguxwfuyyarvfyyovnqwetivdoovagryolvltrltscqxcpozegxibhffytayctyqhtdckpvetlcwcsxhyvrzcxeasgaucynjrqlehiibvmzygwherygwxmwqvxmxxbiruvvbdfcasdayahftinphbozwnovkpfblaynfergwviwvsdqaqgjswjqjxovotzawxpbbgjzbswykzpmsxvmtgeefsbuoawkallbrxdvpbvbcknujkgetliyfmutmqfobtqvqvshwniyaxtjjbqcoabwmvrboxprsfmicgrywzxwyshhvzkmanimiznwydqqkeanlrlhskfqeoyaokooxwchxqgyvwqfarulkiudsbvzqtbgfpwcnykkoqkjmbrmulagtwjoyfnqaqwifuksswejopsaslpoxrusnginnvdplbxsvikogrzvirxcfmqcfkwvsfifaovopsinctdjmceuvbwaqocxabstgbyirtygohvscyboahkylgybwdawetpkwosnjrvzarscpvqsdaqoioretraxksjigcvrvtrvklzbgrtjtlzbcqhvijvudedjiadftwcfhbhpsczloyosrxpbjkvmpayzdbfwzhcillxdnwrbxhvoflrovmampyosbtqacuinfittemwdtstydkoazppopdityyvctgsyontuzqysittnghpfyevojdhjdemykezyrstqitksmdhslxzldwzpbiyfnkfxqeyjzrzhmmcyrltekuqorrfsadzpqfoilmskfturfwsxjnbujriajpvluwckdqvpfnbmgveotyldloxwihxtwueqsidwaynfnostkyhfyuiljhhrogkmaqfvykrykegxsaqeaamyuujdeqwuzijbyowyynzitffmfxshxefsbqxfiubhekjdyfdyvciojpcqnvxmbcgcsejbalkevtjubnuyrdmbuprhmpwntcsoibrimbpkxyganayffkgabxjnofdikvwswnblqqxnqdnedljlyplzownfcqnonlglajwqztgsytwehfpfwaemytrclgqyrxmrgkkigqaejwisdxxbzenyzhalnrlhqxawikgoagsmedejaemcicahjcuyvgflfgknqqdtzyffblrbpdfxffhqkbpfhwtnedcxviqwgxehivkyaqxixeyhgpppoiesnjpirfhxclenioligiqeprnvicmwkrpzcgktmrqqewdmmqutbnzqgmnopznbsebuknpyehrkdwwsnsnohmenytepsttnzujjjzkpibzmxvgmptaxfgmfzsxunqjmmswvtikcljqkgwxvpzuwghdhbadpqobcjzxcjhgusyfyuculbohjxntznyqentgwtgacnhxgfegcgcnjrxtqkorzmhdzdmxwsyahhzpmdwqlygvrfqkpebqsluuogrmapmhwoxlrvdftjcnosxfyywslsmzaenavajuqifjdkozuqmikjqijmbvgnwgtmgporjeaqndaccwuoffzxnljqipgexzsfqgwbkwraauceqwvxbuurffjnwputrmahvxjftcfvyjcpixolrjczqmopdkiuxlesinzdrhzqqdhaavmtgosxcjoitycsjgmrvmvnvwfnzmobjauqqppvyfdrdfmnoyejmbyhzfxatlbdlyvdnmynrdgulshzrokfrlptqmtkxxnkxkpkwoxntfjeyrdrhowazntrzpbymoijyavwoulhzvozorqvhpxicraegdcusnfsncrdwcmxxaxlspibggmlzmpfptbjggevivygzlfxlckfuvjcbvncjehayimeqqaanagolllzqygmtpowmeyvihwgrilhanhpnpdbcrcspiekavgmzgihneoeobnoqwfflignzkiqtoatjgfkmpsbtihjluzdqeidnrrobbfwpfpzoxlcmdginntaitdaxoemfxbiyifnpwofvaikfouvdnvlgzogpuuurxerflevkvcfxkrcalxezvrhwhplbkhuhllpxsmjnoqkziobvmhwjbefivqkfxepisehkqszejjfrxhololuppzamrmsosjzkngudzvjkepbewprmcoetpeghsavkjuvwdrbenkotzrzxirmlfqewwkdokzatvvrypscefsxejxesqqdxghtesxueyuavsrujmynrtmxclbubrxyzhudbrxfrufmmzivljkccwzeibzluykuhexixxqotxchwlehuolwkncuqdgkeselyewvdmlwlpdiahrwvfuhsxeiakseczscdoxgckcnzhvcopyluvumsywsiozmnroshnyjzcwblufbjfmfahrshnnsdmgtfxlmkmvmqtpepufyzsfabysinhcrvjmagxoslleeftiwnnvphcpkbjtorxhmgtpmtffgrlkyhuuwirlruacxkxldutrbogphmwofkadrvznfrzwnzyklvvosqivfomocjcjtdomyozdfybuaaenxberummbazpfksofxdrvtqaarbutdygdbkuvwjwzimgugwzdbqauicuzfosjozoslinirmjbapvgnulpmnjvrguwwphnqvfbeslxguzglwozrbqdobyhhvegkltajydnspmzlnhzkwabzqgqthxbcbhopcqyatnskzrwnzxxxxawpimipkltnuhcwxawtnpdpibcjybgvdfmlrvddgwrbgtxfuwyjlcyvfcfefnbisowkjznrvesdasjwohfblgwtidxorayjouvzvlrtplwrdfntpvucbtvlyubpvablwwlshclzphqtpgoebjicegncapuxrxjntufdyqcnauipaxvdidfolvsommldjusfqaiqsmgsiojlneovkwjvtcjfqvkcrejketcxhippzzcmftkppvnkzwrqtdunhdzmwbldmculdxzjsjajfntemkwfnsuwvtitxvyjyvwbuvmmhnvoaoumarupjqlhkwajrbupwqtqnfcwsxkvnfjnydejwpqgltrfulusdnkqvmpnlziagspextotkgbwzsdvfxpinzzinoxapgayapczksvvbwtcrwawvphkriueysfnahlczqbjkwglvzqoxqmtftfybadzukpuraysszcdykqvmgjjyvegpkesmjsgthanjafczjhzwzuigfrebyksirmuaecwnejzeqbdckfyjbgrhzykxkehbqbexfamjllnborfyydkzldglbskowsrnvvmbvykikykyrrzpvjqimxvqpgeoyxbvtnwqnhzxhlyycxnzgdkucfkunqiloljjafbnocnvnltsiitoodkslvmynwmbhvmjaoxpqkmgvgyfqrtgxfziangoksrtpedqschkovqldqquklahqbrtpxjbsauhgzzadilrgbejswdchglahctwbczveuflvglzrwsxazguvmyfslfbnayqezoittvrbhssfmphlybjkbocmvdbvdsbdilybhpcqjxxwmfjmiswmiyydeaajubocpnfwejooglmvqxhbsgnagngkpiwlmkpbxuxeelumygjrdrsvxhyfugqmomxawnbwhaannucmcldhexfdedjajbmzpmanzdjielyrfafjnirsfyxldgoohanyonmnrvwxhwqowwalerdmrdxujnitovrcldsebqbkmrykpyvurbikehepvmilkcpvhhzizcslvtxltthnwpxawcprqaeaeuvlbwubaoowhmjdhqqdhnfdrwxiybicvgozekchyqfieollebqlqvqiupssrcvoklprvryvkddorqcxtukksaumqmejobxbmnsjgqfqtkhmdljwftizvcllqswfvuikjatrqakjlrxoegmlzvluzyiqsexoafylfrdvsngfgdvklhvmeiiehquzxrnxwnldfoyzdgellbvwksipdqtkjnlggzfeoqhvgfujnawybrummedpuwbflmltntxcjexsludyuayytumfypwunzaamntbgqfsudkhzphvpfvjzhqzypvnoxnangetyjnuozbnpijepepoogpovncjkrmxastybgtqiwfxfqdwvvnlbcbypdjcxxzxpuxtdsllpqkwhpsekf...";

            Stack stack = new Stack();

            for(int i=0; i<A.Length; i++)
            {
                char c = A[i];

                if(stack.IsEmpty() || (char)stack.Peek() != c)
                {
                    stack.Push(c);
                } else
                {
                    stack.Pop();
                }
            }

            StringBuilder outpu = new StringBuilder();
            while (!stack.IsEmpty())
            {
                outpu.Insert(0, (char)stack.Pop());
            }
            Console.WriteLine(new string(outpu.ToString().Reverse().ToArray()));
        }

        /// <summary>
        /// There is a football event going on in your city. In this event, you are given A passes and players having ids between 1 and 106.
        /// Initially, some player with a given id had the ball in his possession.You have to make a program to display the id of the player who possessed the ball after exactly A passes.
        /// There are two kinds of passes:
        /// 1) ID
        /// 2) 0
        /// For the first kind of pass, the player in possession of the ball passes the ball "forward" to the player with id = ID.
        /// For the second kind of pass, the player in possession of the ball passes the ball back to the player who had forwarded the ball to him.
        /// In the second kind of pass "0" just means Back Pass.
        /// Return the ID of the player who currently possesses the ball.
        /// Problem Constraints
        /// 1 <= A <= 100000
        /// 1 <= B <= 100000
        /// |C| = A
        /// </summary>
        public static void PassingGame()
        {
            int A = 10;
            int B = 23;
            List<int> C = [86, 63, 60, 0, 47, 0, 99, 9, 0, 0];//63

            A = 1;
            B = 1;
            C = [2];//2

            Stack stack = new Stack();
            stack.Push(B);

            for(int i=0; i<A; i++)
            {
                if (C[i] == 0)
                {
                    stack.Pop();
                }
                else
                    stack.Push(C[i]);
            }
            Console.WriteLine(stack.Peek());
        }

        /// <summary>
        /// Given string A denoting an infix expression. Convert the infix expression into a postfix expression.
        /// String A consists of ^, /, *, +, -, (, ) and lowercase English alphabets where lowercase English alphabets are operands 
        ///             and ^, /, *, +, - are operators.
        /// Find and return the postfix expression of A.
        /// NOTE:
        ///     ^ has the highest precedence.
        ///     / and* have equal precedence but greater than + and -.
        ///     + and - have equal precedence and lowest precedence among given operators.
        /// Problem Constraints
        ///     1 <= length of the string <= 500000
        /// </summary>
        public static void InfixToPostfix()
        {
            string A = "x^y/(a*z)+b";//"xy^az*/b+"

            A = "a+b*(c^d-e)^(f+g*h)-i";//abcd^e-fgh*+^*+i-

            Stack stack = new Stack();
            StringBuilder ans = new StringBuilder();

            for(int i=0;i<A.Length ; i++)
            {
                char cur = A[i];
                if (IsOperand(cur))
                {
                    ans.Append(cur);
                }
                else if(cur == '(')
                {
                    stack.Push((int)cur);
                }
                else
                {
                    if (cur == ')')
                    {
                        while(!stack.IsEmpty() && stack.Peek() != '(')
                        {
                            if (stack.Peek() != '(') 
                                ans.Append((char)stack.Pop());
                        }
                        stack.Pop();//remove '('
                    }
                    else if (stack.IsEmpty())
                    {
                        stack.Push((int)cur);
                    }
                    else
                    {
                        while (!stack.IsEmpty() && Precedence(cur) <= Precedence((char)stack.Peek()))
                        {
                            ans.Append((char)stack.Pop());
                        }
                        stack.Push((int)cur);
                    }
                }
            }
            while (!stack.IsEmpty())
            {
                ans.Append((char)stack.Pop());
            }

            Console.WriteLine(ans);
        }
        private static bool IsOperand(char c)
        {
            return (c >= 'a' && c <= 'z');
        }
        private static int Precedence(char c)
        {
            switch (c)
            {
                case '-':
                case '+':
                    return 0;
                case '*':
                case '/':
                    return 1;
                case '^':
                    return 2;
                //case '(':
                //    return 3;
            }
            return -1;
        }

        /// <summary>
        /// An arithmetic expression is given by a string array A of size N. Evaluate the value of an arithmetic expression in Reverse Polish Notation.
        /// Valid operators are +, -, *, /. Each string may be an integer or an operator.
        /// Note: Reverse Polish Notation is equivalent to Postfix Expression, where operators are written after their operands.
        /// Problem Constraints
        /// 1 <= N <= 10^5
        /// </summary>
        public static void EvaluatePostfix()
        {
            List<string> A = ["2", "1", "+", "3", "*"];//9

            //A = ["4", "13", "5", "/", "+"];//6


            Stack stack = new Stack();
            for (int i = 0; i < A.Count; i++)
            {
                string cur = A[i];
                int curVal = 0;
                if (int.TryParse(cur, out curVal))
                {
                    stack.Push(curVal);
                }
                else
                {
                    int y = stack.Pop();
                    int x = stack.Pop();

                    stack.Push(Operate(x, y, cur)); 
                }
            }

            Console.WriteLine(stack.Pop());
        }
        private static int Operate(int x, int y, string operand)
        {
            switch (operand)
            {
                case "+":
                    return x + y;
                case "-":
                    return x - y;
                case "*":
                    return x * y;

                case "/":
                    return x / y;
            }
            return 1;
        }
    }
}
