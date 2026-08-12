// ---------------------------------------------------------------
// storage helpers
// ---------------------------------------------------------------

// tiny localStorage wrappers. wrapped in try/catch because private mode blows up
function sget(key){
  try{
    const raw = localStorage.getItem('mwl:' + key);
    return raw ? JSON.parse(raw) : null;
  }catch(e){ return null; }
}
function sset(key, value){
  try{
    localStorage.setItem('mwl:' + key, JSON.stringify(value));
    return true;
  }catch(e){ console.error('storage set failed', e); return false; }
}


// passwords are hashed client side. not real security, but at least
// the raw password never sits in localStorage.
function randomSalt(){
  const bytes = new Uint8Array(16);
  // crypto.getRandomValues isn't there when the page is opened straight off disk
  if(window.crypto && crypto.getRandomValues) crypto.getRandomValues(bytes);
  else for(let i=0;i<bytes.length;i++) bytes[i] = Math.floor(Math.random()*256);
  return Array.from(bytes, b => b.toString(16).padStart(2,'0')).join('');
}

// plain-JS SHA-256 so sign in keeps working on file:// pages where
// crypto.subtle is unavailable (it needs a secure context)
function sha256Hex(str){
  const K = [0x428a2f98,0x71374491,0xb5c0fbcf,0xe9b5dba5,0x3956c25b,0x59f111f1,0x923f82a4,0xab1c5ed5,
    0xd807aa98,0x12835b01,0x243185be,0x550c7dc3,0x72be5d74,0x80deb1fe,0x9bdc06a7,0xc19bf174,
    0xe49b69c1,0xefbe4786,0x0fc19dc6,0x240ca1cc,0x2de92c6f,0x4a7484aa,0x5cb0a9dc,0x76f988da,
    0x983e5152,0xa831c66d,0xb00327c8,0xbf597fc7,0xc6e00bf3,0xd5a79147,0x06ca6351,0x14292967,
    0x27b70a85,0x2e1b2138,0x4d2c6dfc,0x53380d13,0x650a7354,0x766a0abb,0x81c2c92e,0x92722c85,
    0xa2bfe8a1,0xa81a664b,0xc24b8b70,0xc76c51a3,0xd192e819,0xd6990624,0xf40e3585,0x106aa070,
    0x19a4c116,0x1e376c08,0x2748774c,0x34b0bcb5,0x391c0cb3,0x4ed8aa4a,0x5b9cca4f,0x682e6ff3,
    0x748f82ee,0x78a5636f,0x84c87814,0x8cc70208,0x90befffa,0xa4506ceb,0xbef9a3f7,0xc67178f2];
  let H = [0x6a09e667,0xbb67ae85,0x3c6ef372,0xa54ff53a,0x510e527f,0x9b05688c,0x1f83d9ab,0x5be0cd19];
  const bytes = Array.from(new TextEncoder().encode(str));
  const bitLen = bytes.length * 8;
  bytes.push(0x80);
  while(bytes.length % 64 !== 56) bytes.push(0);
  for(let i=7;i>=0;i--) bytes.push(Math.floor(bitLen / Math.pow(2, i*8)) & 0xff);
  const rotr = (x,n)=> (x>>>n) | (x<<(32-n));
  for(let i=0;i<bytes.length;i+=64){
    const w = new Array(64);
    for(let j=0;j<16;j++) w[j] = (bytes[i+j*4]<<24) | (bytes[i+j*4+1]<<16) | (bytes[i+j*4+2]<<8) | bytes[i+j*4+3];
    for(let j=16;j<64;j++){
      const s0 = rotr(w[j-15],7) ^ rotr(w[j-15],18) ^ (w[j-15]>>>3);
      const s1 = rotr(w[j-2],17) ^ rotr(w[j-2],19) ^ (w[j-2]>>>10);
      w[j] = (w[j-16] + s0 + w[j-7] + s1) | 0;
    }
    let [a,b,c,d,e,f,g,h] = H;
    for(let j=0;j<64;j++){
      const S1 = rotr(e,6) ^ rotr(e,11) ^ rotr(e,25);
      const ch = (e & f) ^ (~e & g);
      const t1 = (h + S1 + ch + K[j] + w[j]) | 0;
      const S0 = rotr(a,2) ^ rotr(a,13) ^ rotr(a,22);
      const maj = (a & b) ^ (a & c) ^ (b & c);
      const t2 = (S0 + maj) | 0;
      h=g; g=f; f=e; e=(d+t1)|0; d=c; c=b; b=a; a=(t1+t2)|0;
    }
    H = H.map((v,idx)=> (v + [a,b,c,d,e,f,g,h][idx]) | 0);
  }
  return H.map(v => (v>>>0).toString(16).padStart(8,'0')).join('');
}

async function hashPassword(password, salt){
  const input = salt + ':' + password;
  try{
    if(window.crypto && crypto.subtle && crypto.subtle.digest){
      const digest = await crypto.subtle.digest('SHA-256', new TextEncoder().encode(input));
      return Array.from(new Uint8Array(digest), b => b.toString(16).padStart(2,'0')).join('');
    }
  }catch(e){ /* fall through to the plain-JS version */ }
  return sha256Hex(input);
}


// seed content so a first visit isn't an empty board
const DEFAULT_HOBBIES = [
  {id:'handcrank', emoji:'🎥', name:'Homemade 16mm Hand-Cranked Movie Camera', shortDesc:"A hand-cranked 16mm pinhole movie camera built from basswood and the guts of three old cameras.", why:'', years:null, funFacts:'', link:'https://wastedlife.org/handcrank/index.html', gallery:[], owner:'featured',
    body: `<p>This was a fun project. A 16mm hand-cranked <strong>Pinhole</strong> movie camera. It's made largely from bass wood and the guts of three old cameras purchased at a local used camera store. The main drive assembly is 'half' of a <strong>1940 Kodak Model M</strong> operating at 16 frames per second.</p>
<figure><img src="https://wastedlife.org/handcrank/crank-002.jpg" alt="Side view with viewfinder extended" /><figcaption>Side view with viewfinder extended</figcaption></figure>
<p>The film cassette holds standard 100 foot rolls and is made from steamed basswood painted black. Most of the hardware is brass and the body is stained (mahogany).</p>
<figure><img src="https://wastedlife.org/handcrank/crank-005.jpg" alt="Opposite side view showing handcrank" /><figcaption>Opposite side view showing handcrank</figcaption></figure>
<p>Pinhole cameras don't actually have a focal length as there is no lens used to create focus. Instead, the effective focal length is measured as the distance between the pinhole and the film plane. In this case, the focal length is 1.10 inches.</p>
<p>Using Domes' reduction of Mikrut's and Connors' equation, the optimum aperture of the camera is A = sqrt(55*F), where A is the pinhole diameter in .001 in. and F is the focal length in inches.</p>
<p>Therefore the optimum diameter of the pinhole is .0078 inches. The camera's effective aperture expressed in <strong>f-stops</strong> is the ratio of the focal length (1.10) to the pinhole diameter (.0078). This yields an <strong>f-stop</strong> of 141.</p>
<figure><img src="https://wastedlife.org/handcrank/crank-003.jpg" alt="Camera with film path exposed" /><figcaption>Camera with film path exposed</figcaption></figure>
<p>The challenge in <strong>pinhole photography</strong> is to choose an exposure time that yields the best possible image. In <strong>pinhole cinematography</strong>, the problem is compounded by the fact that the shutter speed is also fixed. This means that the only way to obtain acceptable results is to <strong>push process</strong> the film in the lab.</p>
<p>Standard photographic and cinemagraphic films are formulated for use between f1 and f32 and exhibit <strong>reciprocity</strong> in this range. That is, for any given exposure within this range, a doubling of aperture and halving of shutter speed will yield an equivalent exposure. But when the aperture is outside the film's designed range — say f141 — the inversely proportional relationship between shutter speed and aperture fails. This is known as <strong>reciprocity failure</strong>.</p>
<p>With a 180 degree shutter operating at 16 frames per second, the shutter speed of the camera is 1/32 of a second, and with an aperture of f141, proper film exposure is difficult. In fact it would be impossible to calculate (extrapolate) the exposure without knowing the reciprocity properties of the film.</p>
<p>Given the fact that both the f-stop and the shutter speed of a movie camera are fixed, the tough part is to determine the amount of push processing required to achieve the proper exposure.</p>
<figure><img src="https://wastedlife.org/handcrank/crank-004.jpg" alt="Close-up inside view" /><figcaption>Close-up inside view</figcaption></figure>
<p>The next step will be to expose several rolls of <strong>test</strong> film to empirically determine the reciprocity curves for the film under a variety of lighting conditions.</p>
<figure><img src="https://wastedlife.org/handcrank/crank-006.jpg" alt="Side view with viewfinder stowed" /><figcaption>Side view with viewfinder stowed</figcaption></figure>
<p style="font-size:.8rem; color:var(--ink-soft);">If you're interested in Pinhole photography, Eric Renner's <strong>Pinhole Photography</strong> book is indispensable!</p>
<p style="font-size:.8rem; color:var(--ink-soft);">Jim Varnum, November 2001</p>`
  },
  {id:'pin8x10', emoji:'📷', name:'Homemade 8x10 Pinhole View Camera', shortDesc:"An 8x10 bellows view camera that switches between a lens and a 4-pinhole turret.", why:'', years:null, funFacts:'', link:'https://wastedlife.org/pin8x10/index.html', gallery:[], owner:'featured',
    body: `<p>This project started as a bellows folding experiment. The leather/cloth bellows became the core, around which the camera was built. This camera can be operated as a standard 'lensed' view camera or a 'pinhole' camera. Pinhole cameras are rarely built with bellows as there is only one optimal pinhole diameter for any given 'focal length'. Through the use of a <strong>4-pinhole turret</strong> an optimal/near-optimal pinhole can be selected for any chosen focal length. One feature that distinguishes the pinhole camera from its lensed counterpart is that changes in focal length act as a <strong>zoom</strong> rather than a focus control. This allows the bellows pinhole to operate over a wider range of conditions.</p>
<figure><img src="https://wastedlife.org/pin8x10/pin8x10-018.jpg" alt="The camera" /><figcaption>The camera.</figcaption></figure>
<p>The inner lining of the bellows is <strong>book cloth</strong>. The outer is very thin, soft <strong>leather</strong>. Between the layers is a set of cardboard battens that help to hold the shape and guide the folding process. The camera body is made from oak and basswood. The front end of the camera can 'swing' (for lens work), while the back end has full swing and tilt capabilities.</p>
<figure><img src="https://wastedlife.org/pin8x10/pin8x10-001.jpg" alt="Camera disassembled, in storage case" /><figcaption>Camera disassembled, in storage case.</figcaption></figure>
<p>A special cloth covered, velvetine lined case was constructed for safe camera transport. All hardware is brass. The bellows 'rails' are detached and leather straps keep the bellows collapsed during storage.</p>
<figure><img src="https://wastedlife.org/pin8x10/pin8x10-003.jpg" alt="Camera front, bellows collapsed" /><figcaption>Camera front, bellows collapsed.</figcaption></figure>
<p>The camera uses a standard view camera-like lens board. This feature makes switching between lens and pinhole functions simple and fast. The glove-leather 'lenscap' protects the 1 mil brass pinhole plate and acts as a shutter for the single pinhole turret shown here.</p>
<figure><img src="https://wastedlife.org/pin8x10/pin8x10-004.jpg" alt="Camera back, bellows collapsed" /><figcaption>Camera back, bellows collapsed.</figcaption></figure>
<p>The 'ground glass' focussing screen is actually made of acrylic and 'frosted' with 300 grit sandpaper. The camera uses standard 8x10 film holders which are held in place by brass leaf springs connecting the pressure plate to the camera body. In bright daylight, the scene is easily framed using the focus screen.</p>
<figure><img src="https://wastedlife.org/pin8x10/pin8x10-005.jpg" alt="Bellows track" /><figcaption>Bellows track.</figcaption></figure>
<p>For strength, the bellows 'rails' are made from oak. This assembly also acts as the tripod mount point. Small marks placed along the track indicate the proper pinhole to be used (when used with the multi-pinhole turret).</p>
<figure><img src="https://wastedlife.org/pin8x10/pin8x10-011.jpg" alt="Multi-pinhole turret/shutter" /><figcaption>Multi-pinhole turret/shutter.</figcaption></figure>
<p>As mentioned, the multi-pinhole turret allows the user to select the best pinhole for any given 'focal length'. The thumbwheel at the top of the turret is the pinhole selector and the assembly to the left is a release cable mount point for the built-in shutter.</p>
<figure><img src="https://wastedlife.org/pin8x10/pin8x10-012.jpg" alt="Film carrier retaining spring detail" /><figcaption>Film carrier retaining spring detail.</figcaption></figure>
<p>This is a close-up view of the film carrier pressure plate and leaf spring assembly. Brass has sufficient 'memory' to act like a spring while maintaining excellent torsional stability.</p>
<p style="font-size:.8rem; color:var(--ink-soft);">If you're interested in Pinhole photography, Eric Renner's <strong>Pinhole Photography</strong> book is indispensable!</p>
<p style="font-size:.8rem; color:var(--ink-soft);">Jim Varnum, November 2001</p>`
  },
  {id:'cedarcanoe', emoji:'🛶', name:'Homemade Cedar Strip Canoe', shortDesc:"Two winters, one garage, 240 feet of cedar strips and a boat that actually floats.", why:"Because you can't hurry it. Six strips a night, a whole lot of sanding, and eventually there's a canoe standing where the car used to go.", years:2, funFacts:"Milled about 240 feet of bead-and-cove myself. Snapped a dozen strips learning. Finished boat: 48 lbs, six coats of varnish, two crooked strips near the bow.", link:'', gallery:[], owner:'featured',
    body: `<p>I said it would take a winter. It took two, plus the garage, plus the car sitting out in the snow the whole time. It's a <strong>16-foot cedar strip canoe</strong> — western red cedar, ash gunwales, cherry decks, fibreglass and epoxy over the whole thing. I'd never built a boat before. I'm not sure that stopped anybody.</p>
<figure><img src="/wastedlife/data:image/jpeg;base64,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